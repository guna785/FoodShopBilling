using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetById;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Application.Specifications.Features;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests;
using FoodShopBilling.Utilities.Responses.Features;
using LazyCache;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features.ProductCategories.Queries.GetPaged
{
    public class GetPagedProductCategoryQuery : IRequest<PaginatedResult<ProductCategoryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetPagedProductCategoryQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }
    internal class GetPagedProductCategoryQueryHandler : IRequestHandler<GetPagedProductCategoryQuery, PaginatedResult<ProductCategoryResponse>>
    {
        private readonly IStringLocalizer<GetPagedProductCategoryQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPagedProductCategoryQueryHandler> _logger;
        private readonly IValidator<GetPagedProductCategoryQuery> _addEditProductCategoryCommandValidator;
        private readonly IAppCache _cache;
        public GetPagedProductCategoryQueryHandler(IStringLocalizer<GetPagedProductCategoryQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetPagedProductCategoryQueryHandler> logger, IValidator<GetPagedProductCategoryQuery> addEditProductCategoryCommandValidator)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductCategoryCommandValidator = addEditProductCategoryCommandValidator;
        }
        public async Task<PaginatedResult<ProductCategoryResponse>> Handle(GetPagedProductCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ProductCategory, ProductCategoryResponse>> expression = e => new ProductCategoryResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    LastUpdatedBy = e.LastModifiedBy ?? e.CreatedBy,
                    LastUpdatedOn = e.LastModifiedOn ?? e.CreatedOn   
                };
                ProductCategoryFilterSpecification ManualFilterSpec = new(request.SearchString);
                if (request.OrderBy?.Any() != true)
                {
                    PaginatedResult<ProductCategoryResponse> data = await _unitOfWork.Repository<ProductCategory>().Entities
                       .Specify(ManualFilterSpec)
                       .Select(expression)
                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;
                }
                else
                {
                    string ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                    PaginatedResult<ProductCategoryResponse> data = await _unitOfWork.Repository<ProductCategory>().Entities
                       .Specify(ManualFilterSpec)
                       .OrderBy(ordering) // require system.linq.dynamic.core
                       .Select(expression)
                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;

                }
            }
            catch (Exception ex)
            {
                return (PaginatedResult<ProductCategoryResponse>)await PaginatedResult<ProductCategoryResponse>.FailAsync(ex.Message);
            }
        }
    }
}

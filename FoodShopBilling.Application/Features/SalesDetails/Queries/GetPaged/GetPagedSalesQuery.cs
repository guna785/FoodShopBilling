using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Extensions;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Application.Specifications.Features;
using FoodShopBilling.Shared.Wrapper;
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

namespace FoodShopBilling.Application.Features.SalesDetails.Queries.GetPaged
{
    public class GetPagedSalesQuery : IRequest<PaginatedResult<SalesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetPagedSalesQuery(int pageNumber, int pageSize, string searchString, string orderBy)
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
    internal class GetPagedSalesQueryHandler : IRequestHandler<GetPagedSalesQuery, PaginatedResult<SalesResponse>>
    {
        private readonly IStringLocalizer<GetPagedSalesQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPagedSalesQueryHandler> _logger;
        private readonly IAppCache _cache;
        public GetPagedSalesQueryHandler(IStringLocalizer<GetPagedSalesQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetPagedSalesQueryHandler> logger)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PaginatedResult<SalesResponse>> Handle(GetPagedSalesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Domain.Entities.Sales, SalesResponse>> expression = e => new SalesResponse
                {
                    CustomerName = e.CustomerName,
                    CustomerMobile = e.CustomerMobile,
                    Amount = e.Amount,
                    DiscountAmount = e.DiscountAmount,
                    IsPaid = e.IsPaid,
                    NetAmount = e.NetAmount,
                    PaymentMode = e.PaymentMode,
                    ProductId = e.ProductId,
                    ProductImage = e.Product.ImageUrl,
                    ProductName = e.Product.Name,
                    Quantity = e.Quantity,
                    TaxAmount = e.TaxAmount,
                    TotalAmount = e.TotalAmount
                };
                SalesFilterSpecification ManualFilterSpec = new(request.SearchString);
                if (request.OrderBy?.Any() != true)
                {
                    PaginatedResult<SalesResponse> data = await _unitOfWork.Repository<Domain.Entities.Sales>().Entities
                       .Specify(ManualFilterSpec)
                       .Select(expression)
                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;
                }
                else
                {
                    string ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                    PaginatedResult<SalesResponse> data = await _unitOfWork.Repository<Domain.Entities.Sales>().Entities
                       .Specify(ManualFilterSpec)
                       .OrderBy(ordering) // require system.linq.dynamic.core
                       .Select(expression)
                       .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;

                }
            }
            catch (Exception ex)
            {
                return (PaginatedResult<SalesResponse>)await PaginatedResult<SalesResponse>.FailAsync(ex.Message);
            }
        }
    }
}

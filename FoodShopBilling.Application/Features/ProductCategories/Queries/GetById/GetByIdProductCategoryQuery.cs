using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetAll;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Features;
using LazyCache;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features.ProductCategories.Queries.GetById
{
    public class GetByIdProductCategoryQuery : IRequest<Result<ProductCategoryResponse>>
    {
        public int Id { get; set; }
    }
    internal class GetByIdProductCategoryQueryHandler : IRequestHandler<GetByIdProductCategoryQuery, Result<ProductCategoryResponse>>
    {
        private readonly IStringLocalizer<GetByIdProductCategoryQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdProductCategoryQueryHandler> _logger;
        private readonly IAppCache _cache;
        public GetByIdProductCategoryQueryHandler(IStringLocalizer<GetByIdProductCategoryQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetByIdProductCategoryQueryHandler> logger)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<ProductCategoryResponse>> Handle(GetByIdProductCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var location = await _unitOfWork.Repository<ProductCategory>().GetByIdAsync(request.Id);
                ProductCategoryResponse mappedlocation = _mapper.Map<ProductCategoryResponse>(location);
                return await Result<ProductCategoryResponse>.SuccessAsync(mappedlocation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<ProductCategoryResponse>.FailAsync(ex.Message);
            }
        }
    }
}

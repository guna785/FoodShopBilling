using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Commands.Delete;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Shared.Constants.Application;
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
using static FoodShopBilling.Shared.Constants.Application.ApplicationConstants;

namespace FoodShopBilling.Application.Features.ProductCategories.Queries.GetAll
{
    public class GetAllProductCategoryQuery:IRequest<Result<List<ProductCategoryResponse>>>
    {
    }
    internal class GetAllProductCategoryQueryHandler : IRequestHandler<GetAllProductCategoryQuery, Result<List<ProductCategoryResponse>>>
    {
        private readonly IStringLocalizer<GetAllProductCategoryQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductCategoryQueryHandler> _logger;
        private readonly IValidator<GetAllProductCategoryQuery> _addEditProductCategoryCommandValidator;
        private readonly IAppCache _cache;
        public GetAllProductCategoryQueryHandler(IStringLocalizer<GetAllProductCategoryQueryHandler> localize,IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetAllProductCategoryQueryHandler> logger, IValidator<GetAllProductCategoryQuery> addEditProductCategoryCommandValidator)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductCategoryCommandValidator = addEditProductCategoryCommandValidator;
        }
        public async Task<Result<List<ProductCategoryResponse>>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Task<List<ProductCategory>> getAllMachines()
                {
                    return _unitOfWork.Repository<ProductCategory>().GetAllAsync();
                }

                List<ProductCategory> productCategoryList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllProductCategoryCacheKey, getAllMachines);
                List<ProductCategoryResponse> mappedMachines = _mapper.Map<List<ProductCategoryResponse>>(productCategoryList);
                return await Result<List<ProductCategoryResponse>>.SuccessAsync(data: mappedMachines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<List<ProductCategoryResponse>>.FailAsync(ex.Message);
            }
        }
    }
}

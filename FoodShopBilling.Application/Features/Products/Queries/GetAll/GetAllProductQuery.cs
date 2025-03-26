using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetAll;
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

namespace FoodShopBilling.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<Result<List<ProductResponse>>>
    {
    }
    internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, Result<List<ProductResponse>>>
    {
        private readonly IStringLocalizer<GetAllProductQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductQueryHandler> _logger;
        private readonly IValidator<GetAllProductCategoryQuery> _addEditProductCategoryCommandValidator;
        private readonly IAppCache _cache;
        public GetAllProductQueryHandler(IStringLocalizer<GetAllProductQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetAllProductQueryHandler> logger, IValidator<GetAllProductCategoryQuery> addEditProductCategoryCommandValidator)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductCategoryCommandValidator = addEditProductCategoryCommandValidator;
        }
        public async Task<Result<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Task<List<Domain.Entities.Products>> getAllMachines()
                {
                    return _unitOfWork.Repository<Domain.Entities.Products>().GetAllAsync();
                }

                List<Domain.Entities.Products> productCategoryList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllProductCategoryCacheKey, getAllMachines);
                List<ProductResponse> mappedMachines = _mapper.Map<List<ProductResponse>>(productCategoryList);
                return await Result<List<ProductResponse>>.SuccessAsync(data: mappedMachines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<List<ProductResponse>>.FailAsync(ex.Message);
            }
        }
    }
}

using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Interfaces.Repositories;
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

namespace FoodShopBilling.Application.Features.SalesDetails.Queries.GetAll
{
    public class GetAllSalesQuery : IRequest<Result<List<SalesResponse>>>
    {
    }
    internal class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, Result<List<SalesResponse>>>
    {
        private readonly IStringLocalizer<GetAllSalesQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllSalesQueryHandler> _logger;
        private readonly IAppCache _cache;
        public GetAllSalesQueryHandler(IStringLocalizer<GetAllSalesQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetAllSalesQueryHandler> logger)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<List<SalesResponse>>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Task<List<Domain.Entities.Sales>> getAllMachines()
                {
                    return _unitOfWork.Repository<Domain.Entities.Sales>().GetAllAsync();
                }

                List<Domain.Entities.Sales> SalesCategoryList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllSalesCacheKey, getAllMachines);
                List<SalesResponse> mappedMachines = _mapper.Map<List<SalesResponse>>(SalesCategoryList);
                return await Result<List<SalesResponse>>.SuccessAsync(data: mappedMachines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<List<SalesResponse>>.FailAsync(ex.Message);
            }
        }
    }
}

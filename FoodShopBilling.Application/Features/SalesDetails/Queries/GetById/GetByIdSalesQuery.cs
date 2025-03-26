using AutoMapper;
using FoodShopBilling.Application.Interfaces.Repositories;
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

namespace FoodShopBilling.Application.Features.SalesDetails.Queries.GetById
{
    public class GetByIdSalesQuery : IRequest<Result<SalesResponse>>
    {
        public int Id { get; set; }
    }
    internal class GetByIdSalesQueryHandler : IRequestHandler<GetByIdSalesQuery, Result<SalesResponse>>
    {
        private readonly IStringLocalizer<GetByIdSalesQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdSalesQueryHandler> _logger;
        private readonly IAppCache _cache;
        public GetByIdSalesQueryHandler(IStringLocalizer<GetByIdSalesQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetByIdSalesQueryHandler> logger)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<SalesResponse>> Handle(GetByIdSalesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var location = await _unitOfWork.Repository<Domain.Entities.Sales>().GetByIdAsync(request.Id);
                SalesResponse mappedlocation = _mapper.Map<SalesResponse>(location);
                return await Result<SalesResponse>.SuccessAsync(mappedlocation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<SalesResponse>.FailAsync(ex.Message);
            }
        }
    }
}

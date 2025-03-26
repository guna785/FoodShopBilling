using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetById;
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

namespace FoodShopBilling.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQuery:IRequest<Result<ProductResponse>>
    {
        public int Id { get; set; }
    }
    internal class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, Result<ProductResponse>>
    {
        private readonly IStringLocalizer<GetByIdProductQueryHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdProductQueryHandler> _logger;
        private readonly IAppCache _cache;
        public GetByIdProductQueryHandler(IStringLocalizer<GetByIdProductQueryHandler> localize, IAppCache cache, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetByIdProductQueryHandler> logger)
        {
            _localize = localize;
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<ProductResponse>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var location = await _unitOfWork.Repository<Domain.Entities.Products>().GetByIdAsync(request.Id);
                ProductResponse mappedlocation = _mapper.Map<ProductResponse>(location);
                return await Result<ProductResponse>.SuccessAsync(mappedlocation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                return await Result<ProductResponse>.FailAsync(ex.Message);
            }
        }
    }
}

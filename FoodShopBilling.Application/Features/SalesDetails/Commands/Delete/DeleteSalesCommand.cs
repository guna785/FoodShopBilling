using AutoMapper;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Shared.Constants.Application;
using FoodShopBilling.Shared.Wrapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features.SalesDetails.Commands.Delete
{
    public class DeleteSalesCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteSalesCommandHandler : IRequestHandler<DeleteSalesCommand, Result<int>>
    {
        private readonly IStringLocalizer<DeleteSalesCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSalesCommandHandler> _logger;

        public DeleteSalesCommandHandler(IStringLocalizer<DeleteSalesCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<DeleteSalesCommandHandler> logger)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<int>> Handle(DeleteSalesCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting Existing Sales...");
                var dept = await _unitOfWork.Repository<Domain.Entities.Sales>().GetByIdAsync(command.Id).ConfigureAwait(false);
                if (dept == null)
                {
                    _logger.LogInformation("Sales Deletion started...");
                    await _unitOfWork.Repository<Domain.Entities.Sales>().DeleteAsync(dept!).ConfigureAwait(false);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllSalesCacheKey).ConfigureAwait(false);
                    _logger.LogInformation("Sales Deleted Successfully.");
                    return await Result<int>.SuccessAsync("Sales Deleted Successfully.");
                }
                else
                {
                    _logger.LogError("Sales not Exists.");
                    return await Result<int>.FailAsync("Sales does't exists.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}

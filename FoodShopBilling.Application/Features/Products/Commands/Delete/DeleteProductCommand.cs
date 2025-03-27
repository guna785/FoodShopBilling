using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Commands.Delete;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Domain.Entities;
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

namespace FoodShopBilling.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<int>>
    {
        private readonly IStringLocalizer<DeleteProductCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        public DeleteProductCommandHandler(IStringLocalizer<DeleteProductCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting Existing Product...");
                var dept = await _unitOfWork.Repository<Domain.Entities.Products>().GetByIdAsync(request.Id).ConfigureAwait(false);
                if (dept == null)
                {
                    _logger.LogInformation("Product Deletion started...");
                    await _unitOfWork.Repository<Domain.Entities.Products>().DeleteAsync(dept!).ConfigureAwait(false);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductsCacheKey).ConfigureAwait(false);
                    _logger.LogInformation("Product Deleted Successfully.");
                    return await Result<int>.SuccessAsync("Product Deleted Successfully.");
                }
                else
                {
                    _logger.LogError("Product not Exists.");
                    return await Result<int>.FailAsync("Product does't exists.");
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

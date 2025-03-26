using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit;
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

namespace FoodShopBilling.Application.Features.ProductCategories.Commands.Delete
{
    public class DeleteProductCategoryCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, Result<int>>
    {
        private readonly IStringLocalizer<DeleteProductCategoryCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCategoryCommandHandler> _logger;
        private readonly IValidator<DeleteProductCategoryCommand> _addEditProductCategoryCommandValidator;

        public DeleteProductCategoryCommandHandler(IStringLocalizer<DeleteProductCategoryCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<DeleteProductCategoryCommandHandler> logger, IValidator<DeleteProductCategoryCommand> addEditProductCategoryCommandValidator)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductCategoryCommandValidator = addEditProductCategoryCommandValidator;
        }
        public async Task<Result<int>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting Existing ProductCategory...");
                var dept = await _unitOfWork.Repository<ProductCategory>().GetByIdAsync(request.Id).ConfigureAwait(false);
                if (dept == null)
                {
                    _logger.LogInformation("ProductCategory Deletion started...");
                    await _unitOfWork.Repository<ProductCategory>().DeleteAsync(dept!).ConfigureAwait(false);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductCategoryCacheKey).ConfigureAwait(false);
                    _logger.LogInformation("ProductCategory Deleted Successfully.");
                    return await Result<int>.SuccessAsync("ProductCategory Deleted Successfully.");
                }
                else
                {
                    _logger.LogError("ProductCategory not Exists.");
                    return await Result<int>.FailAsync("ProductCategory does't exists.");
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

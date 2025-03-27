using AutoMapper;
using FluentValidation;
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

namespace FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit
{
    public class AddEditProductCategoryCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    internal class AddEditProductCategoryCommandHandler : IRequestHandler<AddEditProductCategoryCommand, Result<int>>
    {
        private readonly IStringLocalizer<AddEditProductCategoryCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEditProductCategoryCommandHandler> _logger;
        private readonly IValidator<AddEditProductCategoryCommand> _addEditProductCategoryCommandValidator;

        public AddEditProductCategoryCommandHandler(IStringLocalizer<AddEditProductCategoryCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<AddEditProductCategoryCommandHandler> logger, IValidator<AddEditProductCategoryCommand> addEditProductCategoryCommandValidator)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductCategoryCommandValidator = addEditProductCategoryCommandValidator;
        }

        public async Task<Result<int>> Handle(AddEditProductCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("ProductCategory Add/Update Validation Started");
                var validationResult = _addEditProductCategoryCommandValidator.Validate(request);
                if (validationResult.IsValid)
                {
                    _logger.LogInformation("ProductCategory Validation Succeed...");
                    if (request.Id == 0)
                    {
                        _logger.LogInformation("Depart Mapping to DTO for New Record");
                        var dept = _mapper.Map<ProductCategory>(request);
                        if (dept != null)
                        {
                            _logger.LogInformation("ProductCategory {Name} is Staring Adding to ProductCategorys", dept.Name);
                            var res = await _unitOfWork.Repository<ProductCategory>().AddAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductCategoryCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("ProductCategory {Name} is Added Successfully", res.Name);
                            return await Result<int>.SuccessAsync(res.Id, _localize["ProductCategory Saved"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to Map ProductCategory Data");
                        }
                    }
                    else
                    {
                        _logger.LogInformation("Getting Existing ProductCategory Data...");
                        var dept = await _unitOfWork.Repository<ProductCategory>().GetByIdAsync(request.Id);
                        if (dept != null)
                        {
                            dept.Name = request.Name;
                            dept.Description = request.Description;
                            _logger.LogInformation("Updating ProductCategory Data...");
                            await _unitOfWork.Repository<ProductCategory>().UpdateAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductCategoryCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("ProductCategory Updated.");
                            return await Result<int>.SuccessAsync(dept.Id, _localize["ProductCategory Updated"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to find ProductCategory");
                        }
                    }
                }
                else
                {
                    _logger.LogError("ProductCategory Validation Failed {0}", validationResult.Errors);
                    return await Result<int>.FailAsync(validationResult!.Errors!.FirstOrDefault()!.ErrorMessage);
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

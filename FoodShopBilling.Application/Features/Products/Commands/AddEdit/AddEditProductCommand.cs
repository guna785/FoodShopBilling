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

namespace FoodShopBilling.Application.Features.Products.Commands.AddEdit
{
    public class AddEditProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int ProductsId { get; set; }
    }
    internal class AddEditProductCommandHandler : IRequestHandler<AddEditProductCommand, Result<int>>
    {
        private readonly IStringLocalizer<AddEditProductCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEditProductCommandHandler> _logger;
        private readonly IValidator<AddEditProductCommand> _addEditProductsCommandValidator;

        public AddEditProductCommandHandler(IStringLocalizer<AddEditProductCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<AddEditProductCommandHandler> logger, IValidator<AddEditProductCommand> addEditProductsCommandValidator)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditProductsCommandValidator = addEditProductsCommandValidator;
        }
        public async Task<Result<int>> Handle(AddEditProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Products Add/Update Validation Started");
                var validationResult = _addEditProductsCommandValidator.Validate(request);
                if (validationResult.IsValid)
                {
                    _logger.LogInformation("Products Validation Succeed...");
                    if (request.Id == 0)
                    {
                        _logger.LogInformation("Depart Mapping to DTO for New Record");
                        var dept = _mapper.Map<Domain.Entities.Products>(request);
                        if (dept != null)
                        {
                            _logger.LogInformation("Products {Name} is Staring Adding to Productss", dept.Name);
                            var res = await _unitOfWork.Repository<Domain.Entities.Products>().AddAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductsCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("Products {Name} is Added Successfully", res.Name);
                            return await Result<int>.SuccessAsync(res.Id, _localize["Products Saved"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to Map Products Data");
                        }
                    }
                    else
                    {
                        _logger.LogInformation("Getting Existing Products Data...");
                        var dept = await _unitOfWork.Repository<Domain.Entities.Products>().GetByIdAsync(request.Id);
                        if (dept != null)
                        {
                            dept.Name = request.Name;
                            dept.Description = request.Description;
                            _logger.LogInformation("Updating Products Data...");
                            await _unitOfWork.Repository<Domain.Entities.Products>().UpdateAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllProductsCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("Products Updated.");
                            return await Result<int>.SuccessAsync(dept.Id, _localize["Products Updated"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to find Products");
                        }
                    }
                }
                else
                {
                    _logger.LogError("Products Validation Failed {0}", validationResult.Errors);
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

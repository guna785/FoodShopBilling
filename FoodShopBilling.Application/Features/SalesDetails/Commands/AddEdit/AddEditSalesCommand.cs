using AutoMapper;
using FluentValidation;
using FoodShopBilling.Application.Interfaces.Repositories;
using FoodShopBilling.Shared.Constants.Application;
using FoodShopBilling.Shared.Wrapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Features.SalesDetails.Commands.AddEdit
{
    public class AddEditSalesCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerMobile { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string PaymentMode { get; set; }
        public bool IsPaid { get; set; }
    }
    internal class AddEditSalesCommandHandler : IRequestHandler<AddEditSalesCommand, Result<int>>
    {
        private readonly IStringLocalizer<AddEditSalesCommandHandler> _localize;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEditSalesCommandHandler> _logger;
        private readonly IValidator<AddEditSalesCommand> _addEditSalesCommandValidator;

        public AddEditSalesCommandHandler(IStringLocalizer<AddEditSalesCommandHandler> localize, IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<AddEditSalesCommandHandler> logger, IValidator<AddEditSalesCommand> addEditSalesCommandValidator)
        {
            _localize = localize;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _addEditSalesCommandValidator = addEditSalesCommandValidator;
        }
        public async Task<Result<int>> Handle(AddEditSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sales Add/Update Validation Started");
                var validationResult = _addEditSalesCommandValidator.Validate(request);
                if (validationResult.IsValid)
                {
                    _logger.LogInformation("Sales Validation Succeed...");
                    if (request.Id == 0)
                    {
                        _logger.LogInformation("Depart Mapping to DTO for New Record");
                        var dept = _mapper.Map<Domain.Entities.Sales>(request);
                        if (dept != null)
                        {
                            _logger.LogInformation("Sales {Id} is Staring Adding to Saless", dept.Id);
                            var res = await _unitOfWork.Repository<Domain.Entities.Sales>().AddAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllSalesCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("Sales {Id} is Added Successfully", res.Id);
                            return await Result<int>.SuccessAsync(res.Id, _localize["Sales Saved"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to Map Sales Data");
                        }
                    }
                    else
                    {
                        _logger.LogInformation("Getting Existing Sales Data...");
                        var dept = await _unitOfWork.Repository<Domain.Entities.Sales>().GetByIdAsync(request.Id);
                        if (dept != null)
                        {
                            dept.ProductId = request.ProductId;
                            dept.NetAmount = request.NetAmount;
                            dept.Amount = request.Amount;
                            dept.CustomerName = request.CustomerName;
                            dept.CustomerMobile = request.CustomerMobile;
                            dept.DiscountAmount = request.DiscountAmount;
                            dept.PaymentMode = request.PaymentMode;
                            dept.Quantity = request.Quantity;
                            dept.TaxAmount = request.TaxAmount;
                            dept.TotalAmount = request.TotalAmount;
                            dept.IsPaid = request.IsPaid;

                            _logger.LogInformation("Updating Sales Data...");
                            await _unitOfWork.Repository<Domain.Entities.Sales>().UpdateAsync(dept!).ConfigureAwait(false);
                            await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllSalesCacheKey).ConfigureAwait(false);
                            _logger.LogInformation("Sales Updated.");
                            return await Result<int>.SuccessAsync(dept.Id, _localize["Sales Updated"]);
                        }
                        else
                        {
                            return await Result<int>.FailAsync("Unable to find Sales");
                        }
                    }
                }
                else
                {
                    _logger.LogError("Sales Validation Failed {0}", validationResult.Errors);
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

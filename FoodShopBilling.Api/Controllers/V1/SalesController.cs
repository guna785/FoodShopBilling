using FoodShopBilling.Application.Features.SalesDetails.Commands.AddEdit;
using FoodShopBilling.Application.Features.SalesDetails.Commands.Delete;
using FoodShopBilling.Application.Features.SalesDetails.Queries.GetAll;
using FoodShopBilling.Application.Features.SalesDetails.Queries.GetById;
using FoodShopBilling.Application.Features.SalesDetails.Queries.GetPaged;
using FoodShopBilling.Shared.Constants.Permission;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodShopBilling.Api.Controllers.V1
{
    public class SalesController : BaseApiController<SalesController>
    {
        /// <summary>
        /// Get All Saless
        /// </summary
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Sales.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
           PaginatedResult<SalesResponse> brands = await _mediator.Send(new GetPagedSalesQuery(pageNumber, pageSize, searchString!, orderBy!));
            return Ok(brands);
        }

        /// <summary>
        /// Get All Saless for AutoComplete
        /// </summary
        ///<returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Sales.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSelectView()
        {
            Result<List<SalesResponse>> brands = await _mediator.Send(new GetAllSalesQuery());
            return Ok(brands);
        }


        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.Sales.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Result<SalesResponse> brand = await _mediator.Send(new GetByIdSalesQuery() { Id = int.Parse(id) });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Sales
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Sales.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditSalesCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Sales
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Sales.Delete)]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeleteSalesCommand { Id = int.Parse(id) }));
        }

        ///// <summary>
        ///// Search Saless and Export to Excel
        ///// </summary>
        ///// <param name="searchString"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.Sales.Export)]
        //[HttpGet("export")]
        //public async Task<IActionResult> Export(string? searchString = "")
        //{
        //    return Ok(await _mediator.Send(new ExportSalesQuery(searchString)));
        //}

        ///// <summary>
        ///// Import Brands from Excel
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.Sales.Import)]
        //[HttpPost("import")]
        //public async Task<IActionResult> Import(ImportSalesCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}

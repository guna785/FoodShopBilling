using FoodShopBilling.Application.Features.Products.Commands.AddEdit;
using FoodShopBilling.Application.Features.Products.Commands.Delete;
using FoodShopBilling.Application.Features.Products.Queries.GetAll;
using FoodShopBilling.Application.Features.Products.Queries.GetById;
using FoodShopBilling.Application.Features.Products.Queries.GetPaged;
using FoodShopBilling.Shared.Constants.Permission;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodShopBilling.UI.Web.Controllers.V1
{
    public class ProductController : BaseApiController<ProductController>
    {
        /// <summary>
        /// Get All Products
        /// </summary
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Product.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
            PaginatedResult<ProductResponse> brands = await _mediator.Send(new GetPagedProductQuery(pageNumber, pageSize, searchString!, orderBy!));
            return Ok(brands);
        }

        /// <summary>
        /// Get All Products for AutoComplete
        /// </summary
        ///<returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Product.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSelectView()
        {
            Result<List<ProductResponse>> brands = await _mediator.Send(new GetAllProductQuery());
            return Ok(brands);
        }


        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.Product.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Result<ProductResponse> brand = await _mediator.Send(new GetByIdProductQuery() { Id = int.Parse(id) });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Product.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Product.Delete)]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = int.Parse(id) }));
        }

        ///// <summary>
        ///// Search Products and Export to Excel
        ///// </summary>
        ///// <param name="searchString"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.Product.Export)]
        //[HttpGet("export")]
        //public async Task<IActionResult> Export(string? searchString = "")
        //{
        //    return Ok(await _mediator.Send(new ExportProductQuery(searchString)));
        //}

        ///// <summary>
        ///// Import Brands from Excel
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.Product.Import)]
        //[HttpPost("import")]
        //public async Task<IActionResult> Import(ImportProductCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}

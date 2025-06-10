using FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit;
using FoodShopBilling.Application.Features.ProductCategories.Commands.Delete;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetAll;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetById;
using FoodShopBilling.Application.Features.ProductCategories.Queries.GetPaged;
using FoodShopBilling.Shared.Constants.Permission;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodShopBilling.UI.Web.Controllers.V1
{
    
    public class ProductCategoryController : BaseApiController<ProductCategoryController>
    {
        /// <summary>
        /// Get All ProductCategorys
        /// </summary
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.ProductCategory.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
            PaginatedResult<ProductCategoryResponse> brands = await _mediator.Send(new GetPagedProductCategoryQuery(pageNumber, pageSize, searchString!, orderBy!));
            return Ok(brands);
        }

        /// <summary>
        /// Get All ProductCategorys for AutoComplete
        /// </summary
        ///<returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.ProductCategory.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSelectView()
        {
            Result<List<ProductCategoryResponse>> brands = await _mediator.Send(new GetAllProductCategoryQuery());
            return Ok(brands);
        }


        /// <summary>
        /// Get a Brand By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.ProductCategory.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Result<ProductCategoryResponse> brand = await _mediator.Send(new GetByIdProductCategoryQuery() { Id = int.Parse(id) });
            return Ok(brand);
        }


        /// <summary>
        /// Create/Update a ProductCategory
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.ProductCategory.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditProductCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Delete a ProductCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.ProductCategory.Delete)]
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeleteProductCategoryCommand { Id = int.Parse(id) }));
        }

        ///// <summary>
        ///// Search ProductCategorys and Export to Excel
        ///// </summary>
        ///// <param name="searchString"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.ProductCategory.Export)]
        //[HttpGet("export")]
        //public async Task<IActionResult> Export(string? searchString = "")
        //{
        //    return Ok(await _mediator.Send(new ExportProductCategoryQuery(searchString)));
        //}

        ///// <summary>
        ///// Import Brands from Excel
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[Authorize(Policy = Permissions.ProductCategory.Import)]
        //[HttpPost("import")]
        //public async Task<IActionResult> Import(ImportProductCategoryCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}

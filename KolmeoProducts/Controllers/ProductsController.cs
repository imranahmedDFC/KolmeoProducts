using KolmeoProducts.Data;
using KolmeoProducts.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using KolmeoProducts.Core.Domain;
using KolmeoProducts.Services.Product;

namespace KolmeoProducts.Controllers
{   
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        private readonly IProductService _productService;

        public ProductsController(ProductDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<ApiResult<bool>>> AddProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                var productId = await _productService.AddProduct(newProduct);
                if (productId > 0)
                {
                   
                    return Ok(new ApiResult<bool> { Success = true, Message = new List<string> { $"Product with ID {productId} created successfully!" } });
                }
                else
                {
                   
                    return BadRequest(new ApiResult<bool> { Success = false, Message = new List<string> { "Something went wrong" }, Data = newProduct });
                }
            }

            var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new ApiResult<bool> { Success = false, Message = new List<string>(errorMessages), Data = newProduct });
        }



        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<ApiResult<bool>>> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                    return NotFound(new ApiResult<bool> { Success = false, Message = new List<string> { "Product not found" }, Data = updatedProduct });

                var status = await _productService.UpdateProduct(id, updatedProduct);
                if (status)
                    return Ok(new ApiResult<bool> { Success = true, Message = new List<string> { $"Product with ID {id} updated successfully!" } });
                else
                    return BadRequest(new ApiResult<bool> { Success = false, Message = new List<string> { "Something went wrong" }, Data = product });
            }

            var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new ApiResult<bool> { Success = false, Message = new List<string>(errorMessages) });
        }



        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<ActionResult<ApiResult<Product>>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound(new ApiResult<Product> { Success = false, Message = new List<string> { $"Product with ID {id} not found" } });

            return Ok(new ApiResult<Product> { Success = true, Data = product });
        }


        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<ApiResult<IEnumerable<Product>>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            if (products != null && products.Any())
                return Ok(new ApiResult<IEnumerable<Product>> { Success = true, Products = products });
            else
                return NotFound(new ApiResult<IEnumerable<Product>> { Success = false, Message = new List<string> { "No products found" } });
        }


    }

}

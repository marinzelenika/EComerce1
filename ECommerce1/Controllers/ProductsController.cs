using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce1.DTOs;
using ECommerce1.Services;
using Mapster;

namespace ECommerce1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var Products = await _ProductService.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var Product = await _ProductService.GetProductByIdAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDto)
        {
            var product = await _ProductService.AddAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductID }, product.Adapt<ProductDTO>()); // Assuming you have a GetProduct action
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDTO ProductDto)
        {
            if (id != ProductDto.ProductID)
            {
                return BadRequest("Product ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedProduct = await _ProductService.UpdateAsync(ProductDto);
                return Ok(updatedProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await ProductExists(id);
                if (!exists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> ProductExists(int id)
        {
            var Product = await _ProductService.GetProductByIdAsync(id);
            return Product != null;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _ProductService.DeleteAsync(id);
            return NoContent();
        }

    }
}

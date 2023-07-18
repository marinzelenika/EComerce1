using Mapster;
using Microsoft.AspNetCore.Mvc;
using ECommerce1.DTOs;
using ECommerce1.Models;
using ECommerce1.Services;

namespace ECommerce1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.AddAsync(categoryDto);
            var categoryDtoResponse = category.Adapt<CategoryDTO>();
            return CreatedAtAction(nameof(GetCategories), new { id = category.CategoryID }, categoryDtoResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryID)
            {
                return BadRequest();
            }

            var updatedCategory = await _categoryService.UpdateAsync(categoryDto);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}

using Mapster;
using ECommerce1.DTOs;
using ECommerce1.Models;
using ECommerce1.Repositories;

namespace ECommerce1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<Category> AddAsync(CategoryDTO categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            return await _repository.AddAsync(category);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);
            return category.Adapt<CategoryDTO>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Category> UpdateAsync(CategoryDTO categoryDto)
        {
            Category category = categoryDto.Adapt<Category>();
            return await _repository.UpdateAsync(category);
        }


    }
}

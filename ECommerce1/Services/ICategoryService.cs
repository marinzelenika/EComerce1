using ECommerce1.DTOs;
using ECommerce1.Models;

namespace ECommerce1.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<Category> AddAsync(CategoryDTO categoryDto);
        Task<bool> DeleteAsync(int id);
        Task<Category> UpdateAsync(CategoryDTO categoryDto);

    }
}

using Mapster;
using ECommerce1.DTOs;
using ECommerce1.Models;
using ECommerce1.Repositories;

namespace ECommerce1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var Product = await _repository.GetProductByIdAsync(id);
            return Product.Adapt<ProductDTO>();
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var Products = await _repository.GetAllProductsAsync();
            return Products.Adapt<List<ProductDTO>>();
        }
        public async Task<Product> AddAsync(ProductDTO ProductDto)
        {
            var product = ProductDto.Adapt<Product>(); // Using Mapster to map DTO to Entity
            return await _repository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Product> UpdateAsync(ProductDTO ProductDto)
        {
            Product Product = ProductDto.Adapt<Product>();
            return await _repository.UpdateAsync(Product);
        }


    }
}

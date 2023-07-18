using Microsoft.EntityFrameworkCore;
using ECommerce1.Data;
using ECommerce1.Models;

namespace ECommerce1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product Product)
        {
            await _context.Products.AddAsync(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task DeleteAsync(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return;
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Product;
        }



    }
}

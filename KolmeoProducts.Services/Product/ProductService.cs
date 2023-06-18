using KolmeoProducts.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolmeoProducts.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddProduct(Core.Domain.Product product)
        {
            if (product != null)
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task<IEnumerable<Core.Domain.Product>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Core.Domain.Product?> GetProductById(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<bool> UpdateProduct(int id, Core.Domain.Product updatedProduct)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            // Update only the specified fields
            if (!string.IsNullOrEmpty(updatedProduct.Name))
            {
                product.Name = updatedProduct.Name;
            }

            if (!string.IsNullOrEmpty(updatedProduct.Description))
            {
                product.Description = updatedProduct.Description;
            }

            if (updatedProduct.Price != 0)
            {
                product.Price = updatedProduct.Price;
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}

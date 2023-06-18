using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KolmeoProducts.Core.Domain;

namespace KolmeoProducts.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<KolmeoProducts.Core.Domain.Product>> GetAllProducts();
        Task<KolmeoProducts.Core.Domain.Product?> GetProductById(int id);
        Task<int> AddProduct(KolmeoProducts.Core.Domain.Product product);
        Task<bool> UpdateProduct(int id, KolmeoProducts.Core.Domain.Product updatedProduct);
    }
}

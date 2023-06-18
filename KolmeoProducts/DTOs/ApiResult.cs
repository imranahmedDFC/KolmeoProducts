using KolmeoProducts.Core.Domain;

namespace KolmeoProducts.DTOs
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public List<string>? Message { get; set; }
        public Product? Data { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }

}

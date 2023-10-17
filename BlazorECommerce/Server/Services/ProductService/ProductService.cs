using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly PostgreSQLContext _context;

        public ProductService(PostgreSQLContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            if(product == null){
                throw new ArgumentNullException(nameof(product));
            }
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>()
            {
                Data = await _context.products.FindAsync(productId)
           };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.products.ToListAsync()
            };
            return response;
        }
    }
}

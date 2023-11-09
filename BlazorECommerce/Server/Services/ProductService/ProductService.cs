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
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(productId);
            if(product == null){
                response.Success = false;
                response.Message = "Sorry, this product does not exist.";
            }else{
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.ToListAsync()
            };
            return response;
        }
    }
}

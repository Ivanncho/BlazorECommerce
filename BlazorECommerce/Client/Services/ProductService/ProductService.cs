
namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public Product product {get; set;} = new Product();

        public async Task<Product> CreateProduct(Product product)
        {
            try{
                var result = await _http.PostAsJsonAsync<Product>("api/product",product);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadFromJsonAsync<Product>();
            }
            catch (HttpRequestException ex){
                throw ex;
            }
            
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");  // Update the type parameter
            return result;
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if(result != null && result.Data != null)
            {
                Products = result.Data;
            }

        }
    }
}

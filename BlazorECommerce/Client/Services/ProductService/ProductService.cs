
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

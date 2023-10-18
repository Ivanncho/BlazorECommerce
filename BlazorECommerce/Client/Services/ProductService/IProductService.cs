﻿namespace BlazorECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
    }
}

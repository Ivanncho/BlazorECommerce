public interface ICategoryService
{
    Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
}
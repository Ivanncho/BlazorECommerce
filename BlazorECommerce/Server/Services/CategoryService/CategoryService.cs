namespace BlazorECommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly PostgreSQLContext _context;

        public CategoryService(PostgreSQLContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
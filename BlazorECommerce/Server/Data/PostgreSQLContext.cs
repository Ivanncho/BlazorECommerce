namespace BlazorECommerce.Server.Data;
public class PostgreSQLContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
    { }

}

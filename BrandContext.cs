using Microsoft.EntityFrameworkCore;

namespace CrudOperationsInNetCore.Models
{
    public class BrandContext:DbContext
    {
        public BrandContext (DbContextOptions<BrandContext>options):base(options)
        {

        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<ModelInfo> ModelInfo { get; set; }
        public DbSet<BrandDescription> BrandDescription { get; set; }

    }
}

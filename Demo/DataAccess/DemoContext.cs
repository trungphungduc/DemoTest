using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public DbSet<DataAccess.Models.MovieModel> Movie { get; set; }
        public DbSet<DataAccess.Models.ClipModel> Clip { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PCDoctor.Models;

namespace PCDoctor.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
                new Category { Id=1, Name="Mother Boards",DisplayOrder=1},
                new Category { Id=2, Name="Graphics Card",DisplayOrder=2},
                new Category { Id=3, Name="Hard Disks",DisplayOrder=3},
                new Category { Id=4, Name="SSD",DisplayOrder=4},
                new Category { Id=5, Name="PC Peripherals",DisplayOrder=5},
                new Category { Id=6, Name="CPU Coolers",DisplayOrder=6},
                new Category { Id=7, Name="Gaming Chairs",DisplayOrder=7}
                
                );
        }

    }
}

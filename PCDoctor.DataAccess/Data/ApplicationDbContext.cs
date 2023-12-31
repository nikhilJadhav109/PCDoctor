﻿
using Microsoft.EntityFrameworkCore;
using PCDoctor.Models.Models;

namespace PCDoctor.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
                new Category { Id=1, Name="CPU",DisplayOrder=1},
                new Category { Id=2, Name="Graphics Card",DisplayOrder=2},
                new Category { Id=3, Name="Hard Disks",DisplayOrder=3},
                new Category { Id=4, Name="SSD",DisplayOrder=4},
                new Category { Id=5, Name="PC Peripherals",DisplayOrder=5},
                new Category { Id=6, Name="CPU Coolers",DisplayOrder=6},
                new Category { Id=7, Name="Gaming Chairs",DisplayOrder=7}                
             );

            modelBuilder.Entity<Product>().HasData(

                new Product {   Id = 1,
                                Name = "Intel Core i5-13600K", 
                                Description = "Core Count= 6, Clock Speed= 3.7GHz, Boost Speed= 4.6GHz, TDP=65W,Integrated Graphics=None",
                                Manufacturer = "Intel", 
                                Price = 345,
                                CategoryId = 1,
                                ImageUrl=""
                               
                            },
                new Product {   Id = 2,  
                                Name = "Intel Core i9-13900K", 
                                Description = "Core Count= 16, Clock Speed= 4.7GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", 
                                Manufacturer = "Intel",     
                                Price = 654,
                                ImageUrl="",
                                CategoryId = '1',

                            
                              

                },
                new Product {   Id = 3,
                                Name = "AMD Ryzen 5 7600X", 
                                Description = "Core Count= 6, Clock Speed= 4.2GHz, Boost Speed= 6GHz, TDP=65W,Integrated Graphics=Radeon", 
                                Manufacturer = "AMD", 
                                Price = 343,                                
                                ImageUrl = "",
                                CategoryId = 1,
                                
                },
                new Product {   Id = 4, 
                                Name = "Intel Core i7-13700K", 
                                Description = "Core Count= 8, Clock Speed= 4.7GHz, Boost Speed= 5GHz, TDP=65W,Integrated Graphics=Intel UHD Graphics 770", 
                                Manufacturer = "Intel",
                                Price = 532,
                                ImageUrl = "",
                                CategoryId = 1
                                
                },
                new Product {   Id = 5, 
                                Name = "AMD Ryzen 7 5800X", 
                                Description = "Core Count= 8, Clock Speed= 3.7GHz, Boost Speed= 4GHz, TDP=120W,Integrated Graphics=Radeon", 
                                Manufacturer = "AMD", 
                                Price = 245,
                                ImageUrl = "",
                                CategoryId = 1
                               
                }
                );
        }

    }
}

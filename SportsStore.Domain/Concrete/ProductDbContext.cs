
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStore.Domain.Concrete
    {
    public class ProductDbContext : DbContext
        {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext() : base("name=ProductDbConnection")
            {

            }
        }
    }


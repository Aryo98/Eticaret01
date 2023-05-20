using Eticaret01.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret01.Context
{
    public class DataContext:DbContext 
    {
        public DataContext():base("Server=MSI\\SQL; Database=Eticaret; Integrated Security=true")

        { 
        
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }


    }
}

   
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab8.Data
{
    public class lab8Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public lab8Context() : base("name=lab8Context")
        {
        }

        public System.Data.Entity.DbSet<lab8.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<lab8.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<lab8.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<lab8.Models.UniversityCampus> UniversityCampus { get; set; }
    }
}

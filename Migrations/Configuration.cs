namespace lab8.Migrations
{
    using lab8.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<lab8.Data.lab8Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "lab8.Data.lab8Context";
        }
  
        protected override void Seed(lab8.Data.lab8Context context)
        {
            var categories = new List<Category>
    {
        new Category { Name = "Computers and Tablets" },
        new Category { Name = "PC Peripherals" },
        new Category { Name = "PC Parts" },
        new Category { Name = "Networking" },
        new Category { Name = "Printing and Office" },
        new Category { Name = "Software and Games" },
        new Category { Name = "Phones and GPS" },
        new Category { Name = "TV Video and Audio" },
        new Category { Name = "Cameras and Drones" },
        new Category { Name = "Toys and More" },
        new Category { Name = "Apple" }
    };

            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
    {
        new Product
        {
            Name = "Lenovo 510",
            Description = "All in one",
            Price = 631,
            CategoryID = categories.Single(c => c.Name == "Computers and Tablets").ID
        },
        new Product
        {
            Name = "ASUS VE248",
            Description = "LED Gaming Monitor",
            Price = 239,
            CategoryID = categories.Single(c => c.Name == "PC Peripherals").ID
        },
        new Product
        {
            Name = "Samsung S32351",
            Description = "Full HD LED Monitor",
            Price = 369,
            CategoryID = categories.Single(c => c.Name == "PC Peripherals").ID
        },
        new Product
        {
            Name = "ASUS Strix GeForce",
            Description = "GTX1060 Graphics Card 6GB",
            Price = 573,
            CategoryID = categories.Single(c => c.Name == "PC Parts").ID
        },
        new Product
        {
            Name = "8Ware USB Bluetooth",
            Description = "V4 Adapter Version",
            Price = 19.49M,
            CategoryID = categories.Single(c => c.Name == "Networking").ID
        },
        new Product
        {
            Name = "Brother Toner",
            Description = "TN1070 Black 1000 Pages",
            Price = 60.99M,
            CategoryID = categories.Single(c => c.Name == "Printing and Office").ID
        },
        new Product
        {
            Name = "Microsoft Home 10",
            Description = "64 bit",
            Price = 171,
            CategoryID = categories.Single(c => c.Name == "Software and Games").ID
        },
        new Product
        {
            Name = "Microsoft XBox One X",
            Description = "1 TB",
            Price = 749,
            CategoryID = categories.Single(c => c.Name == "TV Video and Audio").ID
        },
        new Product
        {
            Name = "TP Link NC 450",
            Description = "HD Pan Tilt Wifi Camera",
            Price = 163.31M,
            CategoryID = categories.Single(c => c.Name == "Cameras and Drones").ID
        }
    };

            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        
        var campuses = new List<UniversityCampus>
            {
                new UniversityCampus { Name = "Campus A" },
                new UniversityCampus { Name = "Campus B" },
                new UniversityCampus { Name = "Campus C" },
                new UniversityCampus { Name = "Campus D" },
                new UniversityCampus { Name = "Campus E" },
                new UniversityCampus { Name = "Campus F" },
                new UniversityCampus { Name = "Campus G" },
                new UniversityCampus { Name = "Campus H" }
            };

            campuses.ForEach(c => context.UniversityCampus.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { Name = "Alice", Address = "123 Main St", UniversityCampusID = campuses.Single(c => c.Name == "Campus A").ID },
                new Student { Name = "Bob", Address = "456 Elm St", UniversityCampusID = campuses.Single(c => c.Name == "Campus B").ID },
                new Student { Name = "Charlie", Address = "789 Oak St", UniversityCampusID = campuses.Single(c => c.Name == "Campus A").ID },
                new Student { Name = "David", Address = "101 Pine St", UniversityCampusID = campuses.Single(c => c.Name == "Campus C").ID },
                new Student { Name = "Eve", Address = "202 Maple St", UniversityCampusID = campuses.Single(c => c.Name == "Campus D").ID },
                new Student { Name = "Frank", Address = "303 Birch St", UniversityCampusID = campuses.Single(c => c.Name == "Campus E").ID },
                new Student { Name = "Grace", Address = "404 Cedar St", UniversityCampusID = campuses.Single(c => c.Name == "Campus F").ID },
                new Student { Name = "Hank", Address = "505 Walnut St", UniversityCampusID = campuses.Single(c => c.Name == "Campus G").ID }
            };

        students.ForEach(s => context.Students.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }


    }
}

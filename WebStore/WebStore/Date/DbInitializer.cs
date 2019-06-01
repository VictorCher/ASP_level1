﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.DomainNew.Entities;
namespace WebStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebStoreContext context)
        {
            context.Database.EnsureCreated();
            // Look for any products.
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }
            var sections = new List<Section>();
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Sections.Add(section);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                trans.Commit();
            }
            var brands = new List<Brand>();
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var brand in brands)
                {
                    context.Brands.Add(brand);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                trans.Commit();
            }
            var products = new List<Product>();
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[Products] OFF");
                trans.Commit();
            }
        }
    }
}

﻿using Product.API.Entities;
using ILogger = Serilog.ILogger;

namespace Product.API.Persistence
{
    public class ProductContextSeed
    {
        public static async Task SeedProductAsync(ProductContext productContext, ILogger logger)
        {
            if (!productContext.Products.Any())
            {
                productContext.AddRange(GetCatalogProduct());
                await productContext.SaveChangesAsync();
                logger.Information("Seed data for ProductDb associate with context {DbContextName}", nameof(ProductContext));
            }
        }

        private static IEnumerable<CatalogProduct> GetCatalogProduct()
        {
            return new List<CatalogProduct>
            {
                new()
                {
                    No = "Lotus",
                    Name = "Esprit",
                    Summary = "Nondisplaced fracture of greater trochanter of right femur",
                    Description = "Nondisplaced fracture of greater trochanter of right femur",
                    Price = (decimal)177940.49
                },
                new()
                {
                    No = "Cadillac",
                    Name = "CTS",
                    Summary = "Carbuncle of trunk",
                    Description = "Carbuncle of trunk",
                    Price = (decimal)114728.21
                }
            };
        }
    }
}
using ShoppingApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShoppingApplication.Common
{
    public class ShoppingContextSeed
    {
        public static async Task SeedAsync(ShoppingContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText(Path.Combine(path + "/SeedData/brands.json"));
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText(Path.Combine(path + "/SeedData/types.json"));
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.ProductBrands.Any())
            {
                var productsData = File.ReadAllText(Path.Combine(path + "/SeedData/products.json"));
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }
            if (context.ChangeTracker.HasChanges()) { 
                await context.SaveChangesAsync();
                Console.WriteLine("Data Updated");
            }
        }
    }
}

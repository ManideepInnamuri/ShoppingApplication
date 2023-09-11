using IShoppingApplication.Repository;
using Microsoft.EntityFrameworkCore;
using ShoppingApplication.Common;
using ShoppingApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ShoppingContext _shoppingContext;
        public ProductsRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _shoppingContext.Product.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _shoppingContext.Product.FindAsync(id);
            return product;
        }
    }
}

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

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            var products = await _shoppingContext.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _shoppingContext.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).FirstOrDefaultAsync(p => p.Id.Equals(id));
            return product;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var types = await _shoppingContext.ProductTypes.ToListAsync();
            return types;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var brands = await _shoppingContext.ProductBrands.ToListAsync();
            return brands;
        }

        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            var productBrand = await _shoppingContext.ProductBrands.FindAsync(id);
            return productBrand;
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
            var productType = await _shoppingContext.ProductTypes.FindAsync(id);
            return productType;
        }
    }
}

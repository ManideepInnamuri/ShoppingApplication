using ShoppingApplication.Common.Models;

namespace IShoppingApplication.Repository
{
    public interface IProductsRepository
    {
        Task<IReadOnlyList<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypes();

        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<ProductBrand> GetProductBrandById(int id);
        Task<ProductType> GetProductTypeById(int id);

    }
}

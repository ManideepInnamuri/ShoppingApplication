using ShoppingApplication.Common.Models;

namespace IShoppingApplication.Repository
{
    public interface IProductsRepository
    {
        Task<IReadOnlyList<Product>> GetProducts();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();


        Task<Product> GetProductById(int id);
        Task<ProductBrand> GetProductBrandById(int id);
        Task<ProductType> GetProductTypeById(int id);

    }
}

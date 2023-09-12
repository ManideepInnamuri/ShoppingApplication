using ShoppingApplication.Common.Models;

namespace IShoppingApplication.Repository
{
    public interface IProductsRepository
    {
        Task<IReadOnlyList<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}

using ShoppingApplication.Common.Models;

namespace IShoppingApplication.Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}

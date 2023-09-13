using IShoppingApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingApplication.Api.Controllers
{

    public class ProductsController : DefaultController
    {
        private readonly IProductsRepository _productsRepo;
        public ProductsController(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsRepo.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productsRepo.GetProductById(id);
            return Ok(product);
        }

        

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var brands = await _productsRepo.GetProductBrands();
            return Ok(brands);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProductBrandById(int id)
        //{
        //    var productBrand = await _productsRepo.GetProductBrandById(id);
        //    return Ok(productBrand);
        //}


        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var types = await _productsRepo.GetProductTypes();
            return Ok(types);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProductTypeById(int id)
        //{
        //    var productType = await _productsRepo.GetProductTypeById(id);
        //    return Ok(productType);
        //}
    }
}

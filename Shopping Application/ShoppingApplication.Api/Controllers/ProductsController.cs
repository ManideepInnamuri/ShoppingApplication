using AutoMapper;
using IShoppingApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApplication.Common.Dtos;
using ShoppingApplication.Common.Models;
using ShoppingApplication.Repository.Specification;

namespace ShoppingApplication.Api.Controllers
{

    public class ProductsController : DefaultController
    {
        //private readonly IProductsRepository _productsRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        private readonly IGenericRepository<ProductType> _productsTypeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productsBrandRepo, IGenericRepository<ProductType> productsTypeRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productsBrandRepo = productsBrandRepo;
            _productsTypeRepo = productsTypeRepo;
            _mapper = mapper;

        }
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product,ProductToReturnDto>(product));
        }



        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var brands = await _productsBrandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("brand/{id}")]
        public async Task<IActionResult> GetProductBrandById(int id)
        {
            var productBrand = await _productsBrandRepo.GetByIdAsync(id);
            return Ok(productBrand);
        }


        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var types = await _productsTypeRepo.ListAllAsync();
            return Ok(types);
        }

        [HttpGet("type/{id}")]
        public async Task<IActionResult> getproducttypebyid(int id)
        {
            var producttype = await _productsTypeRepo.GetByIdAsync(id);
            return Ok(producttype);
        }
    }
}

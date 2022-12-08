using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceJala.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var item = await _productRepository.GetProductById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Product newProduct = new Product()
            {
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                UnitPrice = product.UnitPrice,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
            await _productRepository.AddProduct(newProduct);
            return Ok(await _productRepository.GetProducts());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProductById(int id)
        {
            await _productRepository.RemoveProductById(id);
            return Ok(await _productRepository.GetProducts());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product newProduct = new Product()
            {
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                UnitPrice = product.UnitPrice,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
            await _productRepository.UpdateProduct(newProduct);
            return Ok(await _productRepository.GetProducts());
        }
    }
}
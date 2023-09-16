using AuthServer.Core.DTOs;
using AuthServer.Core.Model;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace UdemyAuthServer.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDto> _productService;

        public ProductController(IServiceGeneric<Product, ProductDto> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.AddAsync(productDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _productService.Update(productDto, productDto.Id));
        }

        [HttpDelete("{id}")] // api/product/5
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return ActionResultInstance(await _productService.Remove(id));
        }
    }
}
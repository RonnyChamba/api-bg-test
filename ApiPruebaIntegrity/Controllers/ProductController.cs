using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/products")]
    public class ProductController: ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] GenericReqDTO<ProductReqDTO> reqDTO)
        { 
            
            var response = await _productService.SaveProduct(reqDTO);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FindAllProducts(string? paramFilter)
        {

            var response = await _productService.FindAllProducts(paramFilter??"");

            return Ok(response);
        }
    }
}

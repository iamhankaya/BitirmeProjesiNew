using Business;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpPost("addProductImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add(IFormFile file,int productId)
        { 
            ProductImage productImage = new() { };
            var result = await _productImageService.AddImageAsync(productImage, productId, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetALL()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productImageService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere(int id)
        {
            var result = _productImageService.GetWhere(p => p.ProductId == id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

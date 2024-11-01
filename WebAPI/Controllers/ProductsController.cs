using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Product product)
        {
            var result = await _productService.AddAsync(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere()
        {
            var result = _productService.GetWhere(p => p.id == 2);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsingleasync")]

        public async Task<IActionResult> GetSingleAsync()
        {
            var result = await _productService.GetSingleAsync(p => p.id == 1);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyidasync")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addrangeasync")]

        public async Task<IActionResult> AddRange(List<Product> products)
        {
            var result = await _productService.AddRangeAsync(products);
            if(result.Success) 
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Product product)
        {

            var result = await _productService.Update(product);
            if(result.Success) 
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(Product product)
        {
            var result = await _productService.Delete(product);
            if (result.Success) 
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("deleteid")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("deleterange")]
        public async Task<IActionResult> DeleteRange(List<Product> products)
        {
            var result = await _productService.DeleteRange(products);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

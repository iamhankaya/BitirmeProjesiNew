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
        public async Task<IActionResult> Add()
        {
            Product product = new Product
            {
                categoryId = 2,
                description = "Test",
                name = "Test",
                price = 20,
                stockQuantity = 20,
                createTime = DateTime.Now,
            };

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

        public async Task<IActionResult> AddRange()
        {
            Product product1 = new Product
            {
                categoryId = 3,
                description = "Test",
                name = "Test",
                price = 20,
                stockQuantity = 20,
                createTime = DateTime.Now,
            };
            Product product2 = new Product
            {
                categoryId = 2,
                description = "Test",
                name = "Test",
                price = 20,
                stockQuantity = 20,
                createTime = DateTime.Now,
            };
            Product product3 = new Product
            {
                categoryId = 2,
                description = "Test",
                name = "Test",
                price = 20,
                stockQuantity = 20,
                createTime = DateTime.Now,
            };
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            var result = await _productService.AddRangeAsync(products);
            if(result.Success) 
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update()
        {
            Product product = new Product
            {
                id = 1002,
                categoryId = 3,
                description = "Update",
                name = "Update",
                price = 20,
                stockQuantity = 20,
                createTime = DateTime.Now,
            };
            var result = await _productService.Update(product);
            if(result.Success) 
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success) 
                return Ok(result);
            return BadRequest(result);
        }

    }
}

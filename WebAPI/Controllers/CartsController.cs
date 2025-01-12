using Busines.Abstract;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Cart cart)
        {
            cart.totalAmount = 0;
            var result = await _cartService.AddAsync(cart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere(int userId)
        {
            var result = _cartService.GetWhere(p => p.userId == userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsingleasync")]

        public async Task<IActionResult> GetSingleAsync(int cartId)
        {
            var result = await _cartService.GetSingleAsync(p => p.id == cartId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyidasync")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _cartService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addrangeasync")]

        public async Task<IActionResult> AddRange(List<Cart> entities)
        {
            var result = await _cartService.AddRangeAsync(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Cart entity)
        {

            var result = await _cartService.Update(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpPost("addProductToCart")]

        public async Task<IActionResult> AddProductToCart(int cartId,Product product)
        {
            var result = await _cartService.AddProductToCart(cartId,product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("deleteProductFromCart")]

        public async Task<IActionResult> DeleteProductFromCart(int cartId, Product product)
        {
            var result = await _cartService.DeleteProductFromCart(cartId, product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(Cart entity)
        {
            var result = await _cartService.Delete(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("deleteid")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cartService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("deleterange")]
        public async Task<IActionResult> DeleteRange(List<Cart> entities)
        {
            var result = await _cartService.DeleteRange(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

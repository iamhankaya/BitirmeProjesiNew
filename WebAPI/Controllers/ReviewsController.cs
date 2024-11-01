using Busines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Review entity)
        {
            var result = await _reviewService.AddAsync(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _reviewService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere()
        {
            var result = _reviewService.GetWhere(p => p.id == 2);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsingleasync")]

        public async Task<IActionResult> GetSingleAsync()
        {
            var result = await _reviewService.GetSingleAsync(p => p.id == 1);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyidasync")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addrangeasync")]

        public async Task<IActionResult> AddRange(List<Review> entities)
        {
            var result = await _reviewService.AddRangeAsync(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Review entity)
        {

            var result = await _reviewService.Update(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(Review entity)
        {
            var result = await _reviewService.Delete(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("deleteid")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reviewService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("deleterange")]
        public async Task<IActionResult> DeleteRange(List<Review> entities)
        {
            var result = await _reviewService.DeleteRange(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

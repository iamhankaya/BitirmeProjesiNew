using Busines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsManager : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsManager(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Payment entity)
        {
            var result = await _paymentService.AddAsync(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getwhere")]

        public IActionResult GetWhere()
        {
            var result = _paymentService.GetWhere(p => p.id == 2);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsingleasync")]

        public async Task<IActionResult> GetSingleAsync()
        {
            var result = await _paymentService.GetSingleAsync(p => p.id == 1);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyidasync")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _paymentService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addrangeasync")]

        public async Task<IActionResult> AddRange(List<Payment> entities)
        {
            var result = await _paymentService.AddRangeAsync(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Payment entity)
        {

            var result = await _paymentService.Update(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(Payment entity)
        {
            var result = await _paymentService.Delete(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("deleteid")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("deleterange")]
        public async Task<IActionResult> DeleteRange(List<Payment> entities)
        {
            var result = await _paymentService.DeleteRange(entities);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

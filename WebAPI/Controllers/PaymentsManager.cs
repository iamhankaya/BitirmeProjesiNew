using Busines.Abstract;
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
    }
}

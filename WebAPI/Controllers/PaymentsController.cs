using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entites.Concerete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("Payment")]

        public IActionResult Payment(Payment payment)
        {
            var result = _paymentService.IsPaymentValid(payment);
            if (result.Success)
            {
                return Ok(result); 
            };
            return BadRequest(result);

        }
    }
}

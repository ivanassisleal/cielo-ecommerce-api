using Cielo.eCommerce.Api.Entities;
using Cielo.eCommerce.Api.Entities.Enum;
using Cielo.eCommerce.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Test.Controllers
{
    [Route("consult")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private Merchant _merchant;

        public ConsultController()
        {
            _merchant = new Merchant()
            {
                MerchantId = "02b29994-39f1-467a-aae5-313c9862429e",
                MerchantKey = "VSIMBSUACZIJFFJKSCCLFJKMSJDZZYRDEBOPXSMN",
            };
        }

        [HttpGet("recurrentPayment")]
        public ActionResult Recurrent(string id)
        {
            var service = new ConsultService(_merchant, EnvironmentEnum.Sandbox);

            var result = service.ConsultRecurrentPayment(id);

            return Ok(new { result });
        }

        [HttpGet("payment")]
        public ActionResult Payment(string id)
        {
            var service = new ConsultService(_merchant, EnvironmentEnum.Sandbox);

            var result = service.ConsultPayment(id);

            return Ok(new { result });
        }
    }
}

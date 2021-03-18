using Cielo.eCommerce.Api.Entities;
using Cielo.eCommerce.Api.Entities.Enum;
using Cielo.eCommerce.Api.Entities.Input;
using Cielo.eCommerce.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Test.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private Merchant _merchant;

        public TransactionController()
        {
            _merchant = new Merchant()
            {
                MerchantId = "02b29994-39f1-467a-aae5-313c9862429e",
                MerchantKey = "VSIMBSUACZIJFFJKSCCLFJKMSJDZZYRDEBOPXSMN",
            };
        }

        [HttpPost("recurrent")]
        public async Task<ActionResult> Recurrent(CreditCardSimpleRecurrentInput request)
        {
            var transactionService = new TransactionService(_merchant, EnvironmentEnum.Sandbox);

            var result = await transactionService.CreateCreditCardSimpleRecurrentTransactionAsync(request);

            return Ok(new { result });
        }

        [HttpPost("alterPayment")]
        public async Task<ActionResult> AlterPayment(CreditCardAlterPaymentInput request)
        {
            var transactionService = new TransactionService(_merchant, EnvironmentEnum.Sandbox);

            var result = await transactionService.CreditCardRecurrentTransactionAlterPaymentAsync(request);

            return Ok(new { result });
        }

    }
}

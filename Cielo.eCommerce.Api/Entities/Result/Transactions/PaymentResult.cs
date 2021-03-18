using Cielo.eCommerce.Api.Entities.Enum;
using Newtonsoft.Json;
using System;

namespace Cielo.eCommerce.Api.Entities.Result.Transactions
{
    public struct PaymentResult
    {
        public int ServiceTaxAmount { get; set; }

        public int Installments { get; set; }

        public int Interest { get; set; }

        public bool Capture { get; set; }

        public bool Authenticate { get; set; }

        public bool Recurrent { get; set; }

        public CreditCardResult CreditCard { get; set; }

        /// <summary>
        /// Id da transação na adquirente.
        /// </summary>
        public string Tid { get; set; }

        /// <summary>
        /// Texto que será impresso na fatura bancaria do portador - Disponivel apenas para VISA/MASTER - nao permite caracteres especiais
        /// </summary>
        public string SoftDescriptor { get; set; }

        public string Provider { get; set; }

        /// <summary>
        /// Campo Identificador do Pedido.
        /// </summary>
        public string PaymentId { get; set; }

        public string Type { get; set; }

        public int Amount { get; set; }

        public string ProofOfSale { get; set; }

        public string AuthorizationCode { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public string ReturnCode { get; set; }

        public string ReturnMessage { get; set; }

        public TransactionalStatusEnum Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RecurrentPaymentResult RecurrentPayment { get; set; }
    }
}

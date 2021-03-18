using System;

namespace Cielo.eCommerce.Api.Entities.Result.Queries
{
    public struct PaymentResult
    {
        public int ServiceTaxAmount { get; set; }

        public int Installments { get; set; }

        public string Interest { get; set; }

        public bool Capture { get; set; }

        public bool Authenticate { get; set; }
        
        public CreditCardResult CreditCard { get; set; }

        public string ProofOfSale { get; set; }

        /// <summary>
        /// Id da transação na adquirente.
        /// </summary>
        public string Tid { get; set; }

        public string Provider { get; set; }

        /// <summary>
        /// Campo Identificador do Pedido.
        /// </summary>
        public string PaymentId { get; set; }

        public string Type { get; set; }

        public int Amount { get; set; }

        public DateTime ReceivedDate { get; set; }

        public DateTime CapturedDate { get; set; }

        public int CapturedAmount { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public int Status { get; set; }
    }
}

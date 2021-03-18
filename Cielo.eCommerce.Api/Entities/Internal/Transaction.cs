using System;

namespace Cielo.eCommerce.Api.Entities
{
    internal class Transaction
    {
        /// <summary>
        /// Numero de identificação do Pedido.
        /// </summary>
        public string MerchantOrderId { get; set; }

        /// <summary>
        /// Comprador
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Pagamento
        /// </summary>
        public Payment Payment { get; set; }

        public FraudAnalysis FraudAnalysis { get; set; }
    }
}

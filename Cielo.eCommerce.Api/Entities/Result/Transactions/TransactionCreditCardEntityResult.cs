using System;

namespace Cielo.eCommerce.Api.Entities.Result.Transactions
{
    public struct TransactionCreditCardEntityResult
    {
        public string MerchantOrderId { get; set; }

        public CustomerResult Customer { get;set;}

        public PaymentResult Payment { get; set; }
    }
}

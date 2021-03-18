using Cielo.eCommerce.Api.Entities.Enum;
using System;

namespace Cielo.eCommerce.Api.Entities.Result.Transactions
{
    public struct RecurrentPaymentResult
    {
        public string RecurrentPaymentId { get; set; }

        public string NextRecurrency { get; set; }

        public string EndDate { get; set; }

        public string Interval { get; set; }

        public bool AuthorizeNow { get; set; }
    }
}

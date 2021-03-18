namespace Cielo.eCommerce.Api.Entities.Result.Queries
{
    public struct RecurrentTransactionsResult
    {
        public string PaymentId { get; set; }

        public int PaymentNumber { get; set; }

        public int TryNumber { get; set; }

    }
}

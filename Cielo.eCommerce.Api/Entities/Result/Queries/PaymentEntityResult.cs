namespace Cielo.eCommerce.Api.Entities.Result.Queries
{
    public struct PaymentEntityResult
    {
        public string MerchantOrderId { get; set; }

        public CustomerResult Customer { get; set; }

        public PaymentResult Payment { get; set; }
    }
}

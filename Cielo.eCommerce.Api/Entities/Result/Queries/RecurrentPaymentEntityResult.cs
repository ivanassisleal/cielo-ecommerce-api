namespace Cielo.eCommerce.Api.Entities.Result.Queries
{
    public struct RecurrentPaymentEntityResult
    {
        public CustomerResult Customer { get; set; }

        public RecurrentPaymentResult RecurrentPayment { get; set; }
    }
}

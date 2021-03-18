namespace Cielo.eCommerce.Api.Entities.Result.Transactions
{
    public struct CreditCardResult
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public bool SaveCard { get; set; }
        public string Brand { get; set; }
    }
}

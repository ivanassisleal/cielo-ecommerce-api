namespace Cielo.eCommerce.Api.Entities
{
    internal class Customer
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Identity { get; set; }

        public string IdentityType { get; set; }

        public Address Address { get; set; }
    }
}

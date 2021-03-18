using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Entities.Input
{
    public class CreditCardCompleteInput
    {
        public string MerchantOrderId { get; set; }

        public string CustomerIdentity { get; set; }

        public IdentityTypeEnum CustomerIdentityType { get; set; }

        public string CustomerName { get; set; }

        public string CustomerStreet { get; set; }

        public string CustomerNumber { get; set; }

        public string CustomerComplement { get; set; }

        public string CustomerZipCode { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerState { get; set; }

        public string CustomerCountry { get; set; }

        /// <summary>
        /// Valor do Pedido (ser enviado em centavos).
        /// </summary>
        public double PaymentAmount { get; set; }

        /// <summary>
        /// Número de Parcelas.
        /// </summary>
        public int PaymentInstallments { get; set; }

        public string PaymentSoftDescriptor { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardHolder { get; set; }

        public string CreditCardExpirationDate { get; set; }

        public string CreditCardSecurityCode { get; set; }

        public CreditCardBrandEnum CreditCardBrand { get; set; }

    }
}

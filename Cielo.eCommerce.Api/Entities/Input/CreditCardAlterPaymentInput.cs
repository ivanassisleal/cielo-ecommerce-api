using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Entities.Input
{
    public class CreditCardAlterPaymentInput
    {
        public string RecurrentPaymentId { get; set; }

        public PaymentTypeEnum PaymentType { get; set; }

        public decimal PaymentAmount { get; set; }

        public int PaymentInstallments { get; set; }

        public string PaymentSoftDescriptor { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardHolder { get; set; }

        public string CreditCardExpirationDate { get; set; }

        public string CreditCardSecurityCode { get; set; }

        public CreditCardBrandEnum CreditCardBrand { get; set; }
    }
}

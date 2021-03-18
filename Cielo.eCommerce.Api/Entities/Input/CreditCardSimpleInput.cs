using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Entities.Input
{
    public class CreditCardSimpleInput
    {
        public string MerchantOrderId { get; set; }

        public string CustomerName { get; set; }

        /// <summary>
        /// Valor do Pedido (ser enviado em centavos).
        /// </summary>
        public decimal PaymentAmount { get; set; }

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

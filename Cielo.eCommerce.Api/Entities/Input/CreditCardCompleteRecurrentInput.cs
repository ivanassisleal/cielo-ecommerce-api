using Cielo.eCommerce.Api.Entities.Enum;
using System;

namespace Cielo.eCommerce.Api.Entities.Input
{
    public class CreditCardCompleteRecurrentInput
    {
        public string MerchantOrderId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerIdentity { get; set; }

        public IdentityTypeEnum CustomerIdentityType { get; set; }

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
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Número de Parcelas.
        /// </summary>
        public int PaymentInstallments { get; set; }

        public string PaymentSoftDescriptor { get; set; }

        /// <summary>
        /// Booleano para saber se a primeira recorrência já vai ser Autorizada ou não.
        /// </summary>
        public bool RecurrentPaymentAuthorizeNow { get; set; }

        public DateTime RecurrentPaymentEndDate { get; set; }

        /// <summary>
        /// Intervalo da recorrência.
        /// </summary>
        public RecurrentPaymentIntervalEnum RecurrentPaymentInterval { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardHolder { get; set; }

        public string CreditCardExpirationDate { get; set; }

        public string CreditCardSecurityCode { get; set; }

        public string CreditCardSaveCard { get; set; }

        public CreditCardBrandEnum CreditCardBrand { get; set; }

    }
}

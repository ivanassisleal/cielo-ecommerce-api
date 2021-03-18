using Cielo.eCommerce.Api.Entities.Enum;
using System;

namespace Cielo.eCommerce.Api.Entities.Input
{
    public class CreditCardSimpleRecurrentInput
    {
        public string MerchantOrderId { get; set; }

        public string CustomerName { get; set; }

        /// <summary>
        /// Sera convertido em centavos
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


        /// <summary>
        /// Quando informado verdadeiro indica que a recorrência não será autorizada na mesma data da compra
        /// </summary>
        public bool ScheduleRecurrent { get; set; }

        public DateTime ScheduleRecurrentStartDate { get; set; }

        public CreditCardBrandEnum CreditCardBrand { get; set; }

    }
}

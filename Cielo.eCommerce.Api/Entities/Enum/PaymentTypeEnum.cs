using System.ComponentModel;

namespace Cielo.eCommerce.Api.Entities.Enum
{
    public enum PaymentTypeEnum
    {
        [Description("CreditCard")]
        CREDIT_CARD,
        [Description("DebitCard")]
        DEBIT_CARD
    }
}

using System.ComponentModel;

namespace Cielo.eCommerce.Api.Entities.Enum
{
    public enum RecurrentPaymentIntervalEnum
    {
        [Description("Monthly")]
        MONTHLY,
        [Description("Bimonthly")]
        BIMONTHLY,
        [Description("Quarterly")]
        QUARTERLY,
        [Description("SemiAnnual")]
        SEMIANNUAL,
        [Description("Annual")]
        ANNUAL
    }
}

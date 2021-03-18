using System;

namespace Cielo.eCommerce.Api.Utils
{
    public static class CieloApiUtils
    {
        public static string GetErrorApi(string code)
        {
            string result = "";
            if (code == "126")
                result = "A data de validade do cartão de crédito é inválida";
            if (code == "128")
                result = "Numero do cartão superior a 16 digitos";
            return result;
        }


        public static int ConvertToCents(decimal amount)
        {
            int result = 0;

            if (amount > 0)
            {
                int integerValue = (int)Math.Truncate(amount);
                int decimalValue = Convert.ToInt16((Math.Round(amount - integerValue, 2)) * 100);
                result = (integerValue * 100) + decimalValue;
            }

            return result;
        }
    }
}

using System;

namespace Cielo.eCommerce.Api.Exceptions
{
    public class CieloeCommerceApiException : Exception
    {
        public CieloeCommerceApiException(string message) : base(message)
        {
        }
    }
}

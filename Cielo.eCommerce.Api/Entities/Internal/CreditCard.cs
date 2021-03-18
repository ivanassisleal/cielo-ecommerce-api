using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Entities
{
    internal class CreditCard
    {
        public CreditCard()
        {
            SaveCard = false;
        }

        public string CardNumber { get; set; }

        public string Holder { get; set; }

        public string ExpirationDate { get; set; }

        /// <summary>
        /// Código de segurança impresso no verso do cartão.
        /// </summary>
        public string SecurityCode { get; set; }

        /// <summary>
        /// Booleano que identifica se o cartão será salvo para gerar o CardToken.
        /// </summary>
        public bool SaveCard { get; set; }

        public string Brand { get; set; }
    }
}

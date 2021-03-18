using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.eCommerce.Api.Entities
{
    internal class Payment
    {
        /// <summary>
        /// Tipo do Meio de Pagamento
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Valor do Pedido (ser enviado em centavos).
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Número de Parcelas.
        /// </summary>
        public int Installments { get; set; }

        public string SoftDescriptor { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RecurrentPayment RecurrentPayment { get; set; }

        public bool Capture { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}

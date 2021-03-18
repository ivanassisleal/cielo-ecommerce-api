using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.eCommerce.Api.Entities
{
    /// <summary>
    /// Comerciante
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Identificador da loja na Cielo.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Chave Publica para Autenticação Dupla na Cielo.
        /// </summary>
        public string MerchantKey { get; set; }

        /// <summary>
        /// Identificador do Request, utilizado quando o lojista usa diferentes servidores para cada GET/POST/PUT.
        /// </summary>
        public string RequestId { get; set; }
    }
}

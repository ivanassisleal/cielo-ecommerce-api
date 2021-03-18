using Newtonsoft.Json;
using System;

namespace Cielo.eCommerce.Api.Entities
{
    internal class RecurrentPayment
    {
        public DateTime EndDate { get; set; }

        public string Interval { get; set; }

        public bool AuthorizeNow { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }
    }
}

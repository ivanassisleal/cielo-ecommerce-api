using Cielo.eCommerce.Api.Entities;
using System;
using System.Net.Http;
using Cielo.eCommerce.Api.Entities.Result.Queries;
using Newtonsoft.Json;
using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Services
{
    public class ConsultService : ServiceBase
    {
        #region Variables

        private Merchant _merchant;

        #endregion

        #region Constructor

        public ConsultService(Merchant merchant, EnvironmentEnum environmentEnum = EnvironmentEnum.Production) :base(environmentEnum)
        {
            _merchant = merchant;
        }

        #endregion

        #region Public Methods

        public RecurrentPaymentEntityResult ConsultRecurrentPayment(string recurrentPaymentId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApiQuery);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                HttpResponseMessage response = client.GetAsync("/1/RecurrentPayment/" + recurrentPaymentId).Result;

                RecurrentPaymentEntityResult recurrentPaymentResult = new RecurrentPaymentEntityResult();

                if (response.IsSuccessStatusCode)
                    recurrentPaymentResult = JsonConvert.DeserializeObject<RecurrentPaymentEntityResult>(response.Content.ReadAsStringAsync().Result);

                return recurrentPaymentResult;
            }
        }

        public PaymentEntityResult ConsultPayment(string paymentId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApiQuery);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                HttpResponseMessage response = client.GetAsync("/1/sales/" + paymentId).Result;

                PaymentEntityResult paymentEntityResult = new PaymentEntityResult();

                if (response.IsSuccessStatusCode)
                    paymentEntityResult = JsonConvert.DeserializeObject<PaymentEntityResult>(response.Content.ReadAsStringAsync().Result);

                return paymentEntityResult;
            }
        }
        
        #endregion
    }
}

using Cielo.eCommerce.Api.Contracts;
using Cielo.eCommerce.Api.Entities;
using Cielo.eCommerce.Api.Entities.Enum;
using Cielo.eCommerce.Api.Entities.Input;
using Cielo.eCommerce.Api.Entities.Result.Transactions;
using Cielo.eCommerce.Api.Utils;
using Cielo.eCommerce.Api.Utils.Extensions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cielo.eCommerce.Api.Services
{
    public class TransactionService : ServiceBase ,ITransactionService 
    {
        #region Variables

        private Merchant _merchant;

        #endregion

        #region Constructor

        public TransactionService(Merchant merchant, EnvironmentEnum environmentEnum = EnvironmentEnum.Production) : base(environmentEnum)
        {
            _merchant = merchant;
        }

        #endregion

        #region Public Methods

        //Payment
        public async Task<bool> PaymentCancelAsync(string paymentId, decimal amount)
        {
            if ((Convert.ToDecimal(CieloApiUtils.ConvertToCents(amount)) / 100) != amount)
                throw new Exceptions.CieloeCommerceApiException("Existe uma divergência no valor informada em relação a conversão para centavos.");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                HttpResponseMessage response = await client.PutAsync(string.Format("/1/sales/{0}/void?=amount", paymentId, amount), null);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    dynamic contentResult = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
                    throw new Exceptions.CieloeCommerceApiException(string.Format("{0} (Cod.{1})", contentResult[0].Message, contentResult[0].Code));
                }
            }
        }

        //Transaction
        public async Task<TransactionCreditCardEntityResult> CreateCreditCardSimpleTransactionAsync(CreditCardSimpleInput input)
        {
            Transaction transaction = new Transaction()
            {
                MerchantOrderId = input.MerchantOrderId,
                Customer = new Customer()
                {
                    Name = input.CustomerName
                },
                Payment = new Payment()
                {
                    Type = PaymentTypeEnum.CREDIT_CARD.GetEnumDescriptionAttribute(),
                    Amount = CieloApiUtils.ConvertToCents( input.PaymentAmount ),
                    Installments = input.PaymentInstallments,
                    SoftDescriptor = input.PaymentSoftDescriptor,
                    CreditCard = new CreditCard()
                    {
                        CardNumber = input.CreditCardNumber,
                        Holder = input.CreditCardHolder,
                        ExpirationDate = input.CreditCardExpirationDate,
                        Brand = input.CreditCardBrand.GetEnumDescriptionAttribute(),
                        SecurityCode = input.CreditCardSecurityCode
                    },
                    Capture = true
                }
            };

            if ((transaction.Payment.Amount / 100) != input.PaymentAmount)
                throw new Exceptions.CieloeCommerceApiException("Existe uma divergência no valor informado em relação a conversão para centavos");

            return await CreateTransaction(transaction);
        }

        public async Task<TransactionCreditCardEntityResult> CreateCreditCardCompleteRecurrentTransactionAsync(CreditCardCompleteRecurrentInput input)
        {
            Transaction transaction = new Transaction()
            {
                MerchantOrderId = input.MerchantOrderId,
                Customer = new Customer()
                {
                    Name = input.CustomerName,
                    Identity = input.CustomerIdentity,
                    IdentityType = input.CustomerIdentityType.GetEnumDescriptionAttribute(),
                    Address = new Address()
                    {
                        Street = input.CustomerStreet,
                        City = input.CustomerCity,
                        Complement = input.CustomerComplement,
                        Country = input.CustomerCountry,
                        Number = input.CustomerNumber,
                        State = input.CustomerState,
                        ZipCode = input.CustomerZipCode
                    }
                },
                Payment = new Payment()
                {
                    Type = PaymentTypeEnum.CREDIT_CARD.GetEnumDescriptionAttribute(),
                    Amount = CieloApiUtils.ConvertToCents(input.PaymentAmount),
                    Installments = input.PaymentInstallments,
                    SoftDescriptor = input.PaymentSoftDescriptor,
                    RecurrentPayment = new RecurrentPayment()
                    {
                        AuthorizeNow = input.RecurrentPaymentAuthorizeNow,
                        EndDate = input.RecurrentPaymentEndDate,
                        Interval = input.RecurrentPaymentInterval.GetEnumDescriptionAttribute()
                    },
                    CreditCard = new CreditCard()
                    {
                        CardNumber = input.CreditCardNumber,
                        Holder = input.CreditCardHolder,
                        ExpirationDate = input.CreditCardExpirationDate,
                        Brand = input.CreditCardBrand.GetEnumDescriptionAttribute(),
                        SecurityCode = input.CreditCardSecurityCode
                    },
                    Capture = true
                }
            };

            if ((transaction.Payment.Amount / 100) != input.PaymentAmount)
                throw new Exceptions.CieloeCommerceApiException("Existe uma divergência no valor informado em relação a conversão para centavos");

            return await CreateTransaction(transaction);
        }

        // Recurrent Transaction
        public async Task<TransactionCreditCardEntityResult> CreateCreditCardSimpleRecurrentTransactionAsync(CreditCardSimpleRecurrentInput input)
        {
            Transaction transaction = new Transaction()
            {
                MerchantOrderId = input.MerchantOrderId,
                Customer = new Customer()
                {
                    Name = input.CustomerName
                },
                Payment = new Payment()
                {
                    Type = PaymentTypeEnum.CREDIT_CARD.GetEnumDescriptionAttribute(),
                    Amount = CieloApiUtils.ConvertToCents(input.PaymentAmount),
                    Installments = input.PaymentInstallments,
                    SoftDescriptor = input.PaymentSoftDescriptor,
                    RecurrentPayment = new RecurrentPayment()
                    {
                        EndDate = input.RecurrentPaymentEndDate,
                        Interval = input.RecurrentPaymentInterval.GetEnumDescriptionAttribute()
                    },
                    CreditCard = new CreditCard()
                    {
                        CardNumber = input.CreditCardNumber,
                        Holder = input.CreditCardHolder,
                        ExpirationDate = input.CreditCardExpirationDate,
                        Brand = input.CreditCardBrand.GetEnumDescriptionAttribute(),
                        SecurityCode = input.CreditCardSecurityCode
                    },
                    Capture = true
                }
            };

            var centsTo = Convert.ToDecimal(transaction.Payment.Amount) / 100;

            if (centsTo != input.PaymentAmount)
                throw new Exceptions.CieloeCommerceApiException("Existe uma divergência no valor informado em relação a conversão para centavos");

            // Se a recorrencia for programada força a autorização para falso e insere data data inicial da recorrencia.
            if (input.ScheduleRecurrent)
            {
                transaction.Payment.RecurrentPayment.AuthorizeNow = false;
                if (input.ScheduleRecurrentStartDate == DateTime.MinValue)
                    throw new Exceptions.CieloeCommerceApiException("Informar a data de início da recorrência para agendamento");
                else
                    transaction.Payment.RecurrentPayment.StartDate = input.ScheduleRecurrentStartDate;
            }
            else
            {
                transaction.Payment.RecurrentPayment.AuthorizeNow = input.RecurrentPaymentAuthorizeNow;
            }

            return await CreateTransaction(transaction);
        }
        
        public async Task<bool> CreditCardRecurrentTransactionDeactiveAsync(string recurrentPaymentId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                HttpResponseMessage response = await client.PutAsync(string.Format("/1/RecurrentPayment/{0}/Deactivate", recurrentPaymentId),null);

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    throw new Exceptions.CieloeCommerceApiException("Ocorreu um erro interno");

                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    dynamic contentResult = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
                    string code = Convert.ToString(contentResult[0].Code);
                    string description = CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) != "" ? CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) : contentResult[0].Message;
                    throw new Exceptions.CieloeCommerceApiException(string.Format("{0} (Cod.{1})", description, code));
                }
            }
        }

        public async Task<bool> CreditCardRecurrentTransactionAlterAmountAsync(string recurrentPaymentId, decimal amount)
        {
            if ( ( Convert.ToDecimal( CieloApiUtils.ConvertToCents(amount) ) / 100) != amount)
                throw new Exceptions.CieloeCommerceApiException("Existe uma divergência no valor informada em relação a conversão para centavos.");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                var content = new StringContent(JsonConvert.SerializeObject(CieloApiUtils.ConvertToCents(amount)),
                    System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(string.Format("/1/RecurrentPayment/{0}/Amount", recurrentPaymentId),
                    content);

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    throw new Exceptions.CieloeCommerceApiException("Ocorreu um erro interno");

                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    dynamic contentResult = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());

                    string code = Convert.ToString(contentResult[0].Code);
                    string description = CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) != "" ? CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) : contentResult[0].Message;
                    throw new Exceptions.CieloeCommerceApiException(string.Format("{0} (Cod.{1})", description, code));
                }
            }
        }

        public async Task<bool> CreditCardRecurrentTransactionAlterPaymentAsync(CreditCardAlterPaymentInput input)
        {
            if ((Convert.ToDecimal(CieloApiUtils.ConvertToCents(input.PaymentAmount)) / 100) != input.PaymentAmount)
                throw new Exception("Existe uma divergência no valor informada em relação a conversão para centavos");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    Type = input.PaymentType.GetEnumDescriptionAttribute(),
                    Amount = CieloApiUtils.ConvertToCents(input.PaymentAmount),
                    Installments = input.PaymentInstallments,
                    SoftDescriptor = input.PaymentSoftDescriptor,
                    CreditCard = new
                    {
                        Brand = input.CreditCardBrand.GetEnumDescriptionAttribute(),
                        Holder = input.CreditCardHolder,
                        CardNumber = input.CreditCardNumber,
                        ExpirationDate = input.CreditCardExpirationDate
                    }
                }),
                    System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(string.Format("/1/RecurrentPayment/{0}/Payment", 
                    input.RecurrentPaymentId), content);

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    throw new Exceptions.CieloeCommerceApiException("Ocorreu um erro interno");

                if (response.IsSuccessStatusCode)
                    return true;
                else
                {
                    dynamic contentResult = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());

                    string code = Convert.ToString(contentResult[0].Code);
                    string description = CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) != "" ? CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) : contentResult[0].Message;
                    throw new Exceptions.CieloeCommerceApiException(string.Format("{0} (Cod.{1})", description, code));
                }
            }
        }

        #endregion

        #region Internal Methods

        internal async Task<TransactionCreditCardEntityResult> CreateTransaction(Transaction transaction)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GetBaseAddressApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantId", _merchant.MerchantId);
                client.DefaultRequestHeaders.TryAddWithoutValidation("MerchantKey", _merchant.MerchantKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("RequestId", _merchant.RequestId);

                var json = JsonConvert.SerializeObject(transaction);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/1/sales", content);

                TransactionCreditCardEntityResult result = new TransactionCreditCardEntityResult();

                if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    throw new Exceptions.CieloeCommerceApiException("Ocorreu um erro interno");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TransactionCreditCardEntityResult>(responseContent);
                }
                else
                {
                    dynamic contentResult = JsonConvert.DeserializeObject(
                        response.Content.ReadAsStringAsync().Result.ToString());

                    if (contentResult != null)
                    {
                        string code = Convert.ToString(contentResult[0].Code);

                        string description = CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) != "" ?
                            CieloApiUtils.GetErrorApi(Convert.ToString(contentResult[0].Code)) : contentResult[0].Message;

                        throw new Exceptions.CieloeCommerceApiException(string.Format("{0} (Cod.{1})", description, code));
                    }
                }

                return result;
            }
        }

        #endregion
    }
}

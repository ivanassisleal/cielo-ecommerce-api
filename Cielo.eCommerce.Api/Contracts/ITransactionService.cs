using Cielo.eCommerce.Api.Entities.Input;
using Cielo.eCommerce.Api.Entities.Result.Transactions;
using System.Threading.Tasks;

namespace Cielo.eCommerce.Api.Contracts
{
    public interface ITransactionService
    {
        Task<bool> PaymentCancelAsync(string paymentId, decimal amount);
        Task<TransactionCreditCardEntityResult> CreateCreditCardSimpleTransactionAsync(CreditCardSimpleInput input);
        Task<TransactionCreditCardEntityResult> CreateCreditCardCompleteRecurrentTransactionAsync(CreditCardCompleteRecurrentInput input);
        Task<TransactionCreditCardEntityResult> CreateCreditCardSimpleRecurrentTransactionAsync(CreditCardSimpleRecurrentInput input);
        Task<bool> CreditCardRecurrentTransactionDeactiveAsync(string recurrentPaymentId);
        Task<bool> CreditCardRecurrentTransactionAlterAmountAsync(string recurrentPaymentId, decimal amount);
        Task<bool> CreditCardRecurrentTransactionAlterPaymentAsync(CreditCardAlterPaymentInput input);
    }
}

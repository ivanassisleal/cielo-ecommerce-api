using System.ComponentModel;

namespace Cielo.eCommerce.Api.Entities.Enum
{
    public enum TransactionalStatusEnum
    {
        [Description("Aguardando atualização de status")]
        NotFinished = 0,
        [Description("Pagamento apto a ser capturado ou definido como pago")]
        Authorized = 1,
        [Description("Pagamento confirmado e finalizado")]
        PaymentConfirmed = 2,
        [Description("Pagamento negado por Autorizador")]
        Denied = 3,
        [Description("Pagamento cancelado")]
        Voided = 10,
        [Description("Pagamento cancelado após 23:59 do dia de autorização")]
        Refunded = 11,
        [Description("Aguardando Status de instituição financeira")]
        Pending = 12,
        [Description("Pagamento cancelado por falha no processamento ou por ação do AF")]
        Aborted = 13,
        [Description("Recorrência agendada")]
        Scheduled = 20,
    }
}

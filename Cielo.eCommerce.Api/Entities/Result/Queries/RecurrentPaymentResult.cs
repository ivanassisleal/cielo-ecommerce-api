using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.eCommerce.Api.Entities.Result.Queries
{
    public  struct RecurrentPaymentResult
    {
        public string RecurrentPaymentId { get; set; }

        public DateTime NextRecurrency { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Interval { get; set; }

        public int Amount { get; set; }

        public DateTime CreateDate { get; set; }

        public int CurrentRecurrencyTry { get; set; }

        public int RecurrencyDay { get; set; }

        public int SuccessfulRecurrences { get; set; }

        public List<RecurrentTransactionsResult> RecurrentTransactions { get; set; }

        public int Status { get; set; }

    }
}

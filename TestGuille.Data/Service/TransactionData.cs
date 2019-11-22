using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Enum;
using TestGuille.Data.IService;
using TestGuille.Data.Models;

namespace TestGuille.Data.Service
{
    public class TransactionData : ITransactionData
    {
        private readonly TestGuilleDbContext db;
        public TransactionData(TestGuilleDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Transaction> GetByCurrency(string currency)
        {
            return db.Transactions.Where(x => x.CurrencyCode == currency);
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return db.Transactions.Where(x => x.Date >= toDate && x.Date <= fromDate);
        }

        public IEnumerable<Transaction> GetByStatus(StatusEnum status)
        {
            return db.Transactions.Where(x => x.Status == status);
        }
    }
}

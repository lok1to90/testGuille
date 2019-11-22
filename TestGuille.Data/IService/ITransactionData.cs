using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Enum;
using TestGuille.Data.Models;

namespace TestGuille.Data.IService
{
    public interface ITransactionData
    {
        IEnumerable<Transaction> GetByCurrency(string currency);
        IEnumerable<Transaction> GetByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<Transaction> GetByStatus(StatusEnum status);
    }
}

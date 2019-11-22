using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TestGuille.Data.Enum;
using TestGuille.Data.Models;

namespace TestGuille.Web.IRules
{
    public interface ITransactionRules
    {
        IEnumerable<Transaction> GetByCurrency(string currency);
        IEnumerable<Transaction> GetByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<Transaction> GetByStatus(string status);
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using TestGuille.Data.Enum;
using TestGuille.Data.IService;
using TestGuille.Data.Models;
using TestGuille.Business.Helper;
using TestGuille.Web.IRules;

namespace TestGuille.Web.Rules
{
    public class TransactionRules : ITransactionRules
    {
        private readonly ITransactionData db;
        public TransactionRules(ITransactionData db)
        {
            this.db = db;
        }

        public IEnumerable<Transaction> GetByCurrency(string currency)
        {
            return db.GetByCurrency(currency);
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return db.GetByDateRange(fromDate, toDate);
        }

        public IEnumerable<Transaction> GetByStatus(string status)
        {
            return db.GetByStatus((StatusEnum)Enum.Parse(typeof(StatusEnum), status));
        }
    }
}
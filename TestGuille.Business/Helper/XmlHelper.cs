using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestGuille.Data.Enum;
using TestGuille.Data.Models;

namespace TestGuille.Business.Helper
{
    public static class XmlHelper
    {
        public static List<Transaction> FromXml(Stream stream)
        {
            try
            {
                var transactions = new List<Transaction>();
                var doc = new XmlDocument();
                doc.Load(stream);

                foreach (XmlNode node in doc.SelectNodes("/Transactions/Transaction"))
                {
                    var transaction = new Transaction();
                    transaction.NroInvoice = node.Attributes["id"].InnerText;
                    transaction.Date = Convert.ToDateTime(node["TransactionDate"].InnerText);
                    switch (node["Status"].InnerText)
                    {
                        case nameof(StatusXmlEnum.Approved):
                            transaction.Status = StatusEnum.A;
                            break;
                        case nameof(StatusXmlEnum.Done):
                            transaction.Status = StatusEnum.D;
                            break;
                        case nameof(StatusXmlEnum.Rejected):
                            transaction.Status = StatusEnum.R;
                            break;
                        default:
                            break;
                    }
                    XmlNode paymentNode = node.SelectSingleNode("PaymentDetails");
                    transaction.CurrencyCode = paymentNode["CurrencyCode"].InnerText;
                    transaction.Amount = Convert.ToDecimal(paymentNode["Amount"].InnerText, new CultureInfo("en-US"));

                    transactions.Add(transaction);
                }
                return transactions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error data", ex);
            }

        }
    }
}

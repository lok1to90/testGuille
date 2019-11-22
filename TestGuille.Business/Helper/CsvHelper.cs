using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TestGuille.Data.Enum;
using TestGuille.Data.Models;
using TestGuille.Web.Utility;

namespace TestGuille.Business.Helper
{
    public static class CsvHelper
    {
        public static Transaction FromCsv(string csvLine)
        {
            
            var newList = convertToString(csvLine);
            try
            {
                var trans = new Transaction();
                trans.NroInvoice = newList[0];
                trans.Amount = Convert.ToDecimal(newList[1], new CultureInfo("en-US"));
                trans.CurrencyCode = newList[2];
                trans.Date = Convert.ToDateTime(newList[3].Insert(10," "));
                switch (newList[4].ToString())
                {
                    case nameof(StatusCvsEnum.Approved):
                        trans.Status = StatusEnum.A;
                        break;
                    case nameof(StatusCvsEnum.Failed):
                        trans.Status = StatusEnum.R;
                        break;
                    case nameof(StatusCvsEnum.Finished):
                        trans.Status = StatusEnum.D;
                        break;
                    default:
                        break;
                }

                return trans;
            }
            catch (Exception ex)
            {
                Log.Error(csvLine, ex);
                throw new Exception("Error data", ex);
            }
           
        }

        private static List<string> convertToString(string csvLine)
        {
            try
            {
                var charList = csvLine.Replace(" ", string.Empty).ToCharArray();
                var newList = new List<string>();
                var initialPosition = 0;
                bool initial = true;
                int cont = 0;
                for (int i = 0; i < charList.Count(); i++)
                {

                    if (charList[i] != (char)44)
                        cont++;
                    if (charList[i] == (char)34)
                    {

                        if (initial)
                        {
                            initialPosition = i;
                            initial = false;
                        }

                        if (i + 1 < charList.Count() && charList[i + 1] != (char)44)
                        {
                            continue;
                        }
                        else
                        {
                            var line = csvLine.Replace(" ", string.Empty);
                            var value = line.Substring(initialPosition + 1, cont - 2);
                            initial = true;
                            cont = 0;
                            newList.Add(value.ToString());
                        }
                    }
                }

                return newList;
            }
            catch (Exception ex)
            {
                Log.Error(csvLine, ex);
                throw new Exception("Error trying to Convert the file", ex);
            }
        }
    }
}
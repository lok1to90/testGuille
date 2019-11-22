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
    public class UploadFileRules : IUploadFileRules
    {
        private readonly IUploadFileData db;
        public UploadFileRules(IUploadFileData db)
        {
            this.db = db;
        }

        public FormatTypeEnum GetValidExtension(string fileName)
        {
            string extension = "";
            if (!string.IsNullOrEmpty(fileName))
                extension = Path.GetExtension(fileName).Replace(".", "").ToUpper();

            switch (extension)
            {
                case nameof(FormatTypeEnum.CSV):
                    return FormatTypeEnum.CSV;
                case nameof(FormatTypeEnum.XML):
                    return FormatTypeEnum.XML;
                default:
                    return FormatTypeEnum.OTHER;
            }
        }

        public bool IsValidSize(long sizeBytes, int maxSize)
        {
            bool isValid = true;

            if (sizeBytes > maxSize)
                isValid = false;

            return isValid;
        }

        public void SaveData (Stream stream, FormatTypeEnum formatType)
        {
            var upload = new UploadFile();
            upload.UploadDate = DateTime.Now;
            upload.FormatType = formatType;
            upload.Transactions = new List<Transaction>();

            if (formatType == FormatTypeEnum.CSV)
            {
                StreamReader reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    upload.Transactions.Add(CsvHelper.FromCsv(reader.ReadLine()));
                }
            }
            else
            {
                upload.Transactions.AddRange(XmlHelper.FromXml(stream));
            }

            try
            {
                db.SaveData(upload);
            }
            catch (Exception ex)
            {
                throw new Exception("Error save", ex);
            }

        }

    }
}
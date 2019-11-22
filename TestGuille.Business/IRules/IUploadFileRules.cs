using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TestGuille.Data.Enum;

namespace TestGuille.Web.IRules
{
    public interface IUploadFileRules
    {
        FormatTypeEnum GetValidExtension(string fileName);
        bool IsValidSize(long sizeBytes, int maxSize);
        void SaveData(Stream stream, FormatTypeEnum formatType);
    }
}
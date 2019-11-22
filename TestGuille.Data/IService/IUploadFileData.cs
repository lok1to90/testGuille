using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Models;
using TestGuille.Data.Service;

namespace TestGuille.Data.IService
{
    public interface IUploadFileData
    {
        void SaveData(UploadFile uploadFile);
    }
}

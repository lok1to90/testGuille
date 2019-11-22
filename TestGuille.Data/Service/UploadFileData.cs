using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.IService;
using TestGuille.Data.Models;

namespace TestGuille.Data.Service
{
    public class UploadFileData : IUploadFileData
    {
        private readonly TestGuilleDbContext db;

        public UploadFileData(TestGuilleDbContext db)
        {
            this.db = db;
        }
        public void SaveData(UploadFile uploadFile)
        {
            try
            {
                db.UploadFiles.Add(uploadFile);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error trying to save transactions data");
            }
        }
    }
}
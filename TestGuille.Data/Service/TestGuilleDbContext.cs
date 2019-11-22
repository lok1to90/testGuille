using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Models;

namespace TestGuille.Data.Service
{
    public class TestGuilleDbContext : DbContext
    {
        public TestGuilleDbContext() : base("name=DEFAULT_CX")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<UploadFile> UploadFiles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Planilhas.Models
{
    public   class OurDbContext : DbContext
    {
        public OurDbContext():base(System.Configuration.ConfigurationManager.ConnectionStrings["OurConnectionString"].ConnectionString)
        {
            Database.SetInitializer<OurDbContext>(new CreateDatabaseIfNotExists<OurDbContext>());
        }
        public DbSet<UserAccount> userAccount { get; set; }

        public DbSet<diluicao_normal> diluicao_normal { get; set; }
         
        

    }
}
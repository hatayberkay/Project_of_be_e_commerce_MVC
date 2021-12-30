using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace e_commerce.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {

        }

        public virtual DbSet<users_info> users_infos { get; set; }
        public virtual DbSet<products> productss { get; set; }

        public virtual DbSet<categories> categoriess { get; set; }
        public virtual DbSet<brands> brandss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritabanında oluşacak olan tabloların isimlerine s takısı gelmemesi için
            base.OnModelCreating(modelBuilder);
        }
    }
}
using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
    
        public DatabaseContext()
            : base("name=DatabaseContext")
        {

            Database.SetInitializer(new DatabaseInitializer());
        }

     


        public virtual DbSet<users_info> users_infos { get; set; } 
        public virtual DbSet<products> productss { get; set; }
       
        public virtual DbSet<categories> categoriess { get; set; }
        public virtual DbSet<brands> brandss { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritabanýnda oluþacak olan tablolarýn isimlerine s takýsý gelmemesi için
            base.OnModelCreating(modelBuilder);
        }
        //Migratiton : Veritabaný güncelleme
        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>//DropCreateDatabaseIfModelChanges<DatabaseContext> //CreateDatabaseIfNotExists eðer veritabaný yoksa oluþtur <DatabaseContext> içerisindeki dbset lere göre
        {
            protected override void Seed(DatabaseContext context)//Seed metodu veritabaný oluþturulduktan sonra devreye girip iþlem yapmamýzý saðlar
            {
                if (!context.users_infos.Any())
                {
                    context.users_infos.Add(
                        new users_info()
                        {
                            situation = true,
                            user_name = "Admin",
                            password = "123456"
                        }
                        );
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
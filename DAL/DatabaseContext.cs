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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritaban�nda olu�acak olan tablolar�n isimlerine s tak�s� gelmemesi i�in
            base.OnModelCreating(modelBuilder);
        }
        //Migratiton : Veritaban� g�ncelleme
        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>//DropCreateDatabaseIfModelChanges<DatabaseContext> //CreateDatabaseIfNotExists e�er veritaban� yoksa olu�tur <DatabaseContext> i�erisindeki dbset lere g�re
        {
            protected override void Seed(DatabaseContext context)//Seed metodu veritaban� olu�turulduktan sonra devreye girip i�lem yapmam�z� sa�lar
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
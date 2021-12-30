using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
namespace BL
{
   public class categoriesManager
    {
        DatabaseContext context = new DatabaseContext();
        public List<categories> GetAll() //veritabanındaki tüm markaları döndüren metot
        {
            return context.categoriess.ToList();
        }


        public categories Get(int id) //sadece id si gönderilen markayı geri döndüren metot
        {
            return context.categoriess.Find(id);
        }

        public int Add(categories categories)
        {
            context.categoriess.Add(categories);
            return context.SaveChanges();
        }


        public int Update(categories categories)
        {
            context.categoriess.AddOrUpdate(categories);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.categoriess.Remove(Get(id));
            return context.SaveChanges();
        }



    }
}

using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;


namespace BL
{
    public class brandsManager
    {

        DatabaseContext context = new DatabaseContext();
        public List<brands> GetAll() //veritabanındaki tüm markaları döndüren metot
        {
            return context.brandss.ToList();
        }


        public brands Get(int id) //sadece id si gönderilen markayı geri döndüren metot
        {
            return context.brandss.Find(id);
        }

        public int Add(brands brands)
        {
            context.brandss.Add(brands);
            return context.SaveChanges();
        }


        public int Update(brands brands)
        {
            context.brandss.AddOrUpdate(brands);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.brandss.Remove(Get(id));
            return context.SaveChanges();
        }
    }
}

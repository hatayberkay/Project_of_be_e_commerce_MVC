using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace BL
{
  public  class productsManager
    {

        DatabaseContext context = new DatabaseContext();
        public List<products> GetAll() //veritabanındaki tüm markaları döndüren metot
        {
            return context.productss.ToList();
        }


        public products Get(int id) //sadece id si gönderilen markayı geri döndüren metot
        {
            return context.productss.Find(id);
        }

        public int Add(products productss)
        {
            context.productss.Add(productss);
            return context.SaveChanges();
        }


        public int Update(products productss)
        {
            context.productss.AddOrUpdate(productss);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.productss.Remove(Get(id));
            return context.SaveChanges();
        }

    }
}

using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace BL
{
    public class usersinfoManager : Repository<users_info>
    {

        DatabaseContext context = new DatabaseContext();
        public List<users_info> GetAll() //veritabanındaki tüm markaları döndüren metot
        {
            return context.users_infos.ToList();
        }


        public users_info Get(int id) //sadece id si gönderilen markayı geri döndüren metot
        {
            return context.users_infos.Find(id);
        }
        
      

    

        public int Add(users_info users_info)
        {
            context.users_infos.Add(users_info);
            return context.SaveChanges();
        }
      

        public int Update(users_info users_info)
        {
            context.users_infos.AddOrUpdate(users_info);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            context.users_infos.Remove(Get(id));
            return context.SaveChanges();
        }

    }
}

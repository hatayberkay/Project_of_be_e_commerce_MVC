using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class users_info : IEntity
    {
        public int Id { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public string e_mail { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public bool situation { get; set; }

    }
}

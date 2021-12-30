using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class categories : IEntity
    {
        public int Id { get; set; }

        public string category_name { get; set; }
        public string category_description { get; set; }
        public DateTime upload_time { get; set; }
        public bool situation { get; set; }
    }
}

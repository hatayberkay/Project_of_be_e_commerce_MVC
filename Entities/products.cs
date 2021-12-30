using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class products : IEntity
    {
        public int Id { get; set; }
        public int categories_id { get; set; }
        public int brands_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public DateTime upload_time { get; set; }
        public int product_fee { get; set; }
        public int tax { get; set; }
        public int number_of_products { get; set; }
        public bool situation { get; set; }
        public string photo { get; set; }
    }
}

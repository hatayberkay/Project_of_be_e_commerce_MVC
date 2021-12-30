using System.Collections.Generic;
namespace e_commerce.Models
{
    public class AnasayfaVM
    {
        public List<Entities.products> products { get; set; }
        public List<Entities.categories> categories { get; set; }
        public List<Entities.brands> brands { get; set; }
    }
}
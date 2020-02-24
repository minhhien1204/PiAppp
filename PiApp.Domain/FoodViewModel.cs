using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Domain
{
    public class FoodViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? PricePromotion { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CategoryId { get; set; }
        public string NameOfCategory { get; set; }
    }
}

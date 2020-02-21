using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiApp.Core.Models
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public virtual List<Food> Foods { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Order
    {
        public List<Product> Products { get; private set; }
        public DateTime Date { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Product
    {
        private int iD;
        private int amountInStock;
        
        public int ID { get => iD; set => iD = value; }
        public int AmountInStock { get => amountInStock; set => amountInStock = value; }
    }
}

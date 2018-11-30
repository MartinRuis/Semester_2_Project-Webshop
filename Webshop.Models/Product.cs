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
        private string productName;
        private int deliveryTime;
        private decimal price;
        private int productTypeID;
        private int manufacuturerID;
        private bool active;
        
        public int ID { get => iD; set => iD = value; }
        public int AmountInStock { get => amountInStock; set => amountInStock = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int DeliveryTime { get => deliveryTime; set => deliveryTime = value; }
        public decimal Price { get => price; set => price = value; }
        public int ProductTypeID { get => productTypeID; set => productTypeID = value; }
        public int ManufacuturerID { get => manufacuturerID; set => manufacuturerID = value; }
        public bool Active { get => active; set => active = value; }
    }

}

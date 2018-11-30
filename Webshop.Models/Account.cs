using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Account
    {
        //fields
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
        public string Password { get; set; }

        //constructor
        //public Account(int account_id, string first_name, string last_name, string initials, string email, string delivery_address)
        //{
        //    this.account_id = account_id;
        //    this.first_name = first_name;
        //    this.last_name = last_name;
        //    this.initials = initials;
        //    this.email = email;
        //    this.delivery_address = delivery_address;
        //}
    }
}

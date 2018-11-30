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
        public int AccountId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Initials { get; private set; }
        public string Email { get; private set; }
        public string DeliveryAddress { get; private set; }

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

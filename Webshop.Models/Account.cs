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
        public int account_id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public string initials { get; private set; }
        public string email { get; private set; }
        public string delivery_address { get; private set; }

        //constructor
        public Account(int account_id, string first_name, string last_name, string initials, string email, string delivery_address)
        {
            this.account_id = account_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.initials = initials;
            this.email = email;
            this.delivery_address = delivery_address;
        }
    }
}

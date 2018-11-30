using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using MySql.Data.MySqlClient;

namespace Webshop.DAL
{
    public class OrderContext : SqlContext
    {
        public bool Create(Account account, Order order)
        {
            foreach (Product product in order.Products)
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("date_of_order1", MySqlDbType.Date));
                parameters.Add(new MySqlParameter("product_id1", MySqlDbType.Int32));
                parameters.Add(new MySqlParameter("account_id1", MySqlDbType.Int32));
                parameters[0].Value = order.Date;
                parameters[1].Value = product.ID;
                parameters[2].Value = account.AccountId;

                try
                {
                    ExecuteInputProc("create_order", parameters);
                    return true;
                }catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public Order Get()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using MySql.Data.MySqlClient;

namespace Webshop.DAL
{
    public class ProductContext : SqlContext
    {
        public bool Create()
        {
            throw new NotImplementedException();
            
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public bool CheckStock(Product product)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@product_id1", MySqlDbType.Int32) { Value = product.ID });

            try
            {
                if ((int)ExecuteOutputProc("check_stock", parameters, 1, new string[] { "" })[0] >= 1){
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

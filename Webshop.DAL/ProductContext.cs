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
        public bool Create(Product product)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("product_name1", MySqlDbType.VarChar) { Value = product.ProductName});
            parameters.Add(new MySqlParameter("delivery_time1", MySqlDbType.Int32) { Value = product.DeliveryTime});
            parameters.Add(new MySqlParameter("price1", MySqlDbType.Decimal) { Value = product.Price });
            parameters.Add(new MySqlParameter("producttype_id1", MySqlDbType.Int32) { Value = product.ProductTypeID});
            parameters.Add(new MySqlParameter("manufacturer_id1", MySqlDbType.Int32) { Value = product.ManufacuturerID});
            parameters.Add(new MySqlParameter("active1", MySqlDbType.TinyBlob) { Value = product.Active });

            try
            {
                ExecuteInputProc("create_product", parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


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

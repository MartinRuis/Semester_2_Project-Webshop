using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using MySql.Data.MySqlClient;

namespace Webshop.DAL
{
    public class ProductTypeContext : SqlContext
    {
        public bool Create(string product_name)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("product_name", MySqlDbType.VarChar) { Value = product_name });

            try
            {
                ExecuteInputProc("create_product_type", parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ProductType Get(Product product)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("producttype_id1", MySqlDbType.Int32) { Value = product.ProductTypeID });
            List<object> o = ExecuteOutputProc("get_product_type", parameters, 1, new string[] { "product_type_name"});
            return new ProductType { TypeID = product.ProductTypeID, TypeName = o[0].ToString() };
        }

        public List<ProductType> GetAllTypes()
        {
            List<MySqlParameter> parameters = null;
            throw new NotImplementedException();
        }
    }
}

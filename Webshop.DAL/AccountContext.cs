using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Webshop.DAL
{
    public class AccountContext : SqlContext
    {
        //create an account
        public bool Create(string first_name, string last_name, string initials, string email, string delivery_address, string password)
        {
            string salt = CreateSalt();
            string hashed_password = GenerateHash(password, salt);

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            
            parameters.Add(new MySqlParameter("first_name1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("last_name1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("initials1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("is_admin1", MySqlDbType.TinyBlob));
            parameters.Add(new MySqlParameter("email1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("delivery_address1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("hashed_passwodd1", MySqlDbType.VarChar));
            parameters.Add(new MySqlParameter("salt1", MySqlDbType.VarChar));
            parameters[0].Value = first_name;
            parameters[1].Value = last_name;
            parameters[2].Value = initials;
            parameters[3].Value = 0;
            parameters[4].Value = email;
            parameters[5].Value = delivery_address;
            parameters[6].Value = hashed_password;
            parameters[7].Value = salt;
            try
            {
                ExecuteInputProc("create_account", parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //delete an account
        public bool Delete(int account_id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@account_id", account_id));
            try
            {
                ExecuteInputProc("delete_account", parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //get an account
        public void Get()
        {

        }

        public string CreateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];

                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);

                    int value = BitConverter.ToInt32(data, 0);
                    rng.Dispose();
                    return value.ToString();
                }
            }
            return "";
        }

        public string GenerateHash(string password, string salt)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(bytes);
        }

    }
}

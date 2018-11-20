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
        public void Create(string first_name, string last_name, string initials, string email, string delivery_address, string password)
        {
            string salt = CreateSalt();
            string hashed_password = GenerateHash(password, salt);

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("@first_name", first_name));
            parameters.Add(new MySqlParameter("@last_name", last_name));
            parameters.Add(new MySqlParameter("@initials", initials));
            parameters.Add(new MySqlParameter("@is_admin", 1));
            parameters.Add(new MySqlParameter("@email", email));
            parameters.Add(new MySqlParameter("@delivery_address", delivery_address));
            parameters.Add(new MySqlParameter("@hashed_passwodd", hashed_password));
            parameters.Add(new MySqlParameter("@salt", salt));
            
            ExecuteInputProc("create_account", parameters);
        }

        //delete an account
        public void Delete(int account_id)
        {

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

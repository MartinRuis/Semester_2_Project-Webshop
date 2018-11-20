using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Webshop.DAL
{
    public class SqlContext
    {
        protected string connection_string = @"server=studmysql01.fhict.local;user id=dbi395898;database=dbi395898;password=5edigvis";

        public void ExecuteInputProc(string procedure_name, List<MySqlParameter> parameters)
        {
            using (var conn = new MySqlConnection(connection_string))
            {
                using (var command = new MySqlCommand(procedure_name, conn) { CommandType = CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();

                        //foreach (MySqlParameter parameter in parameters)
                        //{
                        //    Console.Write(parameter.ParameterName.ToString() + ": ");
                        //    Console.WriteLine(parameter.Value.ToString()); 
                        //    parameter.Direction = ParameterDirection.Input;
                        //    command.Parameters.Add(parameter);
                        //}
                        command.Parameters.Add(new MySqlParameter("@first_name", MySqlDbType.VarChar) { Value = "Martin" });
                        command.Parameters.Add(new MySqlParameter("@last_name", MySqlDbType.VarChar) { Value = "Ruis" });
                        command.Parameters.Add(new MySqlParameter("@initials", MySqlDbType.VarChar) { Value = "G.B." });
                        command.Parameters.Add(new MySqlParameter("@is_admin", MySqlDbType.TinyBlob) { Value = 1 });
                        command.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar) { Value = "ruismartin98@gmail.com" });
                        command.Parameters.Add(new MySqlParameter("@delivery_address", MySqlDbType.VarChar) { Value = "Vestdijk 33A" });
                        command.Parameters.Add(new MySqlParameter("@hashed_passwodd", MySqlDbType.VarChar) { Value = "Wachtwoord" });
                        command.Parameters.Add(new MySqlParameter("@salt", MySqlDbType.VarChar) { Value = "12345" });
                        Console.WriteLine(command.Parameters[0].Value.ToString());
                        Console.ReadKey();
                        command.ExecuteNonQuery();
                                                
                    }
                    catch (MySqlException e)
                    {
                        Console.Write(e.ToString());
                        Console.ReadKey();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.Write(e.ToString());
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.ToString());
                        Console.ReadKey();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public List<object> ExecuteOutputProc(string procedure_name, List<MySqlParameter> parameters, int object_amount, string[] return_columns)
        {
            List<object> returnobject = new List<object>();

            using (var conn = new MySqlConnection(connection_string))
            {
                using (var command = new MySqlCommand(procedure_name, conn) { CommandType = CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();

                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            for (int x = 0; x < object_amount; x++)
                            {
                                returnobject.Add(reader[return_columns[x]]);
                            }
                        }

                    }
                    catch (SqlException e)
                    {
                        Console.Write(e.ToString());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.Write(e.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return returnobject;
        }
    }
}

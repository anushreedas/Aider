using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aider.Model
{
    
    class LoginModel
    {

        public bool Validate(string username, string password)
        {
            bool valid = false;
            OracleConnection myConnection = new OracleConnection();
            OracleDataReader reader = null;
            try
            {
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                myConnection.Open();
                Console.WriteLine("Connection State: " + myConnection.State);

                string cmdstr = "SELECT E_EMAIL_ID,PASSWORD FROM EMPLOYEE";

                OracleCommand cmd = new OracleCommand(cmdstr, myConnection);

                reader = cmd.ExecuteReader();
                if (reader.HasRows) Console.WriteLine("has rows database");
                else Console.WriteLine("no rows");
                while (reader.Read())
                {
                    //Console.WriteLine("Connected to database");
                    Console.WriteLine(reader.GetString(0));
                    if ((username == reader.GetString(0)) && (password == reader.GetString(1)))
                    { valid = true; break; }
                    else
                        valid = false;
                }
                
            }
            catch
            {
                MessageBox.Show("db error");
            }
            finally
            {
                reader.Dispose();
                myConnection.Close();
            }
            return valid;
        }
    }
}

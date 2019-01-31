using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aider.Model
{
    public class Thread
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public char IsPrivate { get; set; }

        public string Members { get; set; }

        public Thread()
        {
            
        }

        public void Revisit()
        {

        }

    }
    class ThreadModel : ObservableObject
    {
        private ObservableCollection<Thread> dataSource;
        public ObservableCollection<Thread> DataSource
        {
            get {return dataSource; }
            set {dataSource=value; RaisePropertyChangedEvent("DataSource"); }
        }

        public ThreadModel()
        {
            OracleConnection myConnection = new OracleConnection();
            OracleDataReader reader = null;
            try
            {
                dataSource = new ObservableCollection<Thread>();
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                myConnection.Open();
                Console.WriteLine("Connection State: " + myConnection.State);
                
                string cmdstr = "SELECT * FROM thread";

                OracleCommand cmd = new OracleCommand(cmdstr, myConnection);

                reader = cmd.ExecuteReader();
                if (reader.HasRows) Console.WriteLine("has rows database");
                else Console.WriteLine("no rows");
                while (reader.Read())
                {
                    Thread t = new Thread();
                    Console.WriteLine("Connected to database");
                    t.Id = reader.GetInt16(0);
                    t.Name = reader.GetString(1);
                    //t.Description = reader.GetString(2);
                    //t.IsPrivate = reader.GetChar(3);
                    //t.Members = reader.GetString(4);
                    Console.WriteLine(t.Id + " " + t.Name);
                    dataSource.Add(t);
                }
                foreach(Thread th in dataSource)
                    Console.WriteLine(th.Id + " " + th.Name);
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
            //dataSource = Document.Open<Thread>("visitors.xml");
        }

        public ObservableCollection<Thread> ReadThreads()
        {
            OracleConnection myConnection = new OracleConnection();
            OracleDataReader reader = null;
            try
            {
                dataSource = new ObservableCollection<Thread>();
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                myConnection.Open();
                Console.WriteLine("Connection State: " + myConnection.State);

                string cmdstr = "SELECT * FROM thread";

                OracleCommand cmd = new OracleCommand(cmdstr, myConnection);

                reader = cmd.ExecuteReader();
                if (reader.HasRows) Console.WriteLine("has rows database");
                else Console.WriteLine("no rows");
                while (reader.Read())
                {
                    Thread t = new Thread();
                    Console.WriteLine("Connected to database");
                    t.Id = reader.GetInt16(0);
                    t.Name = reader.GetString(1);
                    //t.Description = reader.GetString(2);
                    //t.IsPrivate = reader.GetChar(3);
                    //t.Members = reader.GetString(4);
                    Console.WriteLine(t.Id + " " + t.Name);
                    dataSource.Add(t);
                }
                foreach (Thread th in dataSource)
                    Console.WriteLine(th.Id + " " + th.Name);
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
            return dataSource;
        }

        public List<string> ThreadNames()
        {
            List<string> tn = new List<string>();
            foreach (Thread t in dataSource)
                tn.Add(t.Name.ToString());
            return tn;
        }

        public void WriteThread(string tn, string ds, bool ip, List<string> mem)
        {

            OracleConnection myConnection = new OracleConnection();
           // OracleDataReader reader = null;
            try
            {
                dataSource = new ObservableCollection<Thread>();
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                myConnection.Open();
                Console.WriteLine("Connection State for writing: " + myConnection.State);
                 char ispriv= (ip== true )? 'y' : 'n';

                string cmdstr = "INSERT INTO thread(id,name,descrip,private) VALUES(1010,'"+tn+"','"+ds+"','"+ispriv+"')";
                
                OracleCommand cmd = new OracleCommand(cmdstr, myConnection);
    
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                {
                    MessageBox.Show("Record not inserted");
                }
                else
                {
                }
                foreach (Thread th in dataSource)
                    Console.WriteLine(th.Id + " " + th.Name);
            }
            catch
            {
                MessageBox.Show("db error");
            }
            finally
            {
               // reader.Dispose();
                myConnection.Close();
            }
        
        }
    }
}

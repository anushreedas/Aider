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
    public class Thread : ObservableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IsPrivate { get; set; }
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
                
                string cmdstr = "SELECT THREAD_ID,NAME,DESCRIPTION,PRIVATE FROM thread";

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
                    t.Description = reader.GetString(2);
                    t.IsPrivate = reader.GetString(3);
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

                string cmdstr = "SELECT THREAD_ID,NAME,DESCRIPTION,PRIVATE FROM thread";

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
                    t.Description = reader.GetString(2);
                    t.IsPrivate = reader.GetString(3);
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

        public ObservableCollection<Thread> WriteThread(string tn, string ds, bool ip)
        {

            OracleConnection myConnection = new OracleConnection();
           // OracleDataReader reader = null;
            try
            {
                dataSource = new ObservableCollection<Thread>();
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                myConnection.Open();
                Console.WriteLine("Connection State for writing: " + myConnection.State);
                char ispriv = (ip == true) ? 'y' : 'n';

                string cmdstr = "INSERT INTO THREAD(THREAD_ID, NAME,DESCRIPTION,E_DATE ,PRIVATE  ) VALUES(THREAD_SEQUENCE.nextval, '" + tn+"', '"+ds+"',TO_DATE(SYSDATE),'"+ispriv+"')";

                OracleCommand cmd = new OracleCommand(cmdstr, myConnection);

                int rowsUpdated = cmd.ExecuteNonQuery();

                
                if (rowsUpdated == 0)
                {
                    MessageBox.Show("Record not inserted");
                }
                else
                {
                    //MessageBox.Show("qUERYY SUCCESSFULL");
                }
               
                Console.WriteLine("updated table");
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
            return ReadThreads();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.OracleClient;

namespace Aider.Model
{
    public class LoginModel : INotifyPropertyChanged
    {
        public string userName;
        public string password;
        public string validation;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != null)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != null)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }


        public string Validation
        {
            get
            {
                return validation;
            }
            set
            {
                string ora = "DATA SOURCE=localhost:1521/orcl.168.117.131;PERSIST SECURITY INFO=True;USER ID=ABC;PASSWORD=ROOT";
                using (OracleConnection myConnection = new OracleConnection(ora))
                {
                    myConnection.Open();

                    string cmdstr = "SELECT * FROM test";

                    OracleCommand cmd = new OracleCommand(cmdstr, myConnection);

                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                    }

                }
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

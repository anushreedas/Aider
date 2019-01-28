using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Aider.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        MainWindow w = new MainWindow();

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
                
            OracleConnection myConnection = new OracleConnection();
            try
                {
               
                
                
                myConnection.ConnectionString = "user id = aider; password = 123456; data source = orcl11g";
                
                myConnection.Open();
                w.Show();
                Hide();
                    
                    MessageBox.Show("connected");
                    //dataGrid1.ItemsSource = dt.DefaultView;           
                }
                catch
                {
                    MessageBox.Show("db error");
                }
                finally
                {
                    myConnection.Close();
                }
            
            //w.Show();
            //Hide();
        }
    }
}

using Aider.Model;
using Aider.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Aider.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        LoginModel model = new LoginModel();

        public new event PropertyChangedEventHandler PropertyChanged;

        private string username;
        private string password;
        private string message;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Username"));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
            }
        }


        private bool CanExecuteLogin()
        {
            Console.WriteLine("Can execute Login!!"); return true;
        }
        private bool flag;
        

        private void ExecuteLogin()
        {
            flag = model.Validate(Username, Password);
            Console.WriteLine("Login!!");
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
            if (flag == true)
            {
                MainWindow w = new MainWindow();
                w.Show();
                CloseWindow();
            }
            else
            {
                Message = "Incorrect Username and Password!!";
                RaisePropertyChanged("Message"); 
            }

           Console.WriteLine("Message"+Message);
        }

        class LoginCommand : ICommand
        {
            internal LoginViewModel Parent;

            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }

                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }

            bool ICommand.CanExecute(object parameter)
            {
                return Parent.CanExecuteLogin();
            }

            void ICommand.Execute(object parameter)
            {
                Parent.ExecuteLogin();
            }
        }
        //public Login<Window> CloseWindowCommand { get; private set; }
        public ICommand Login
        {
            get { return new LoginCommand { Parent = this }; }
        }
    }
}

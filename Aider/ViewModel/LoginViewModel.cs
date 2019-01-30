using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Aider.Model;
using System.Windows;
using System.Windows.Input;
using Aider.Command;

namespace Aider.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private LoginModel _LoginModel;



        public LoginModel Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                NotifyPropertyChanged("Login");
            }
        }

        private ObserICommand _LogInCommand;
        public ICommand LogInCommand
        {
            get
            {
                if (_LogInCommand == null)
                {
                    _LogInCommand = new RelayCommand(LogInExecute, CanLogInExecute, false);
                }
                return _LogInCommand;
            }
        }

        private void LogInExecute(object parameter)
        {
            // add loginin 
        }

        private bool CanLogInExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_LoginModel.UserName) || string.IsNullOrEmpty(_LoginModel.Password))
            {
                return false;
                // if user enter null values in the text boxes then it return false
            }

            else
            {
                //logic of username and password comparison
                return true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Aider.Model;

namespace Aider.ViewModel
{
    public class CreateThreadViewModel : INotifyPropertyChanged
    {
        ThreadModel model = new ThreadModel();

        public event PropertyChangedEventHandler PropertyChanged;
        //private ObservableCollection<Thread> threads;
        private ObservableCollection<Thread> threadnames;

        public ObservableCollection<Thread> Threadnames
        {
            get { return model.ReadThreads(); }
            set {threadnames=value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Threadnames")); }
        }

        private string threadName;
        private string description;
        private bool isPrivate;
        private List<string> members=new List<string>();

        public string ThreadName
        {
            get { return threadName; }
            set
            {
                threadName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThreadName"));
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }
        public bool IsPrivate
        {
            get { return isPrivate; }
            set
            {
                isPrivate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPrivate"));
            }
        }
        public List<string> Members
        {
            get { return members; }
            set
            {
                members = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Members"));
            }
        }

        //private string nameToRegister;

    private bool CanExecuteRegister()
    {
            Console.WriteLine("Can execute!!"); return true;
    }

    private void ExecuteRegister()
    {
            model.WriteThread(threadName,description,isPrivate,members);
            ExecuteRefresh();
            //threadnames.Clear();
            //Threadnames = model.ReadThreads();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Threadnames"));
    }

        private void ExecuteRefresh()
        {
            Threadnames = model.ReadThreads();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Threadnames"));
        }

        class RefreshCommand:ICommand
        {
            internal CreateThreadViewModel Parent;

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
                return Parent.CanExecuteRegister();
            }

            void ICommand.Execute(object parameter)
            {
                Parent.ExecuteRefresh();
            }
        }

        public ICommand Refresh
        {
            get { return new RefreshCommand { Parent = this }; }
        }



        class RegisterCommand : ICommand
    {
        internal CreateThreadViewModel Parent;

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
            return Parent.CanExecuteRegister();
        }

        void ICommand.Execute(object parameter)
        {
            Parent.ExecuteRegister();
        }
    }

    public ICommand Register
    {
        get {  return new RegisterCommand { Parent = this }; }
    }
}
}

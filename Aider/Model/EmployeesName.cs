using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Aider.Model
{
    
    public class Employee : ObservableObject
    {
        private string name;
        private bool _isChecked;

        public string Name
        {
            get {return name; }
            set { name = value; RaisePropertyChangedEvent("Name"); }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; RaisePropertyChangedEvent("IsChecked"); }
        }
        

        public Employee(string s)
        {
            this.name = s;
            this._isChecked = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

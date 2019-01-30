using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Aider.Model
{
    
    public class Employee:ObservableObject
    {
        private string ename;
        private bool _isChecked;

        public string Ename
        {
            get {return ename; }
            set { ename = value; }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
        

        public Employee(string s)
        {
            this.ename = s;
            this._isChecked = false;
        }
    }
}

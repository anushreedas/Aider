using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aider.Model
{
    public class GroupMember : ObservableObject 
    {
        private string name;
        private bool _isChecked;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChangedEvent("Name"); }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; RaisePropertyChangedEvent("IsChecked"); }
        }


        public GroupMember(string s)
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

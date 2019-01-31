using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aider.Model
{
    public class Employee  : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobNo { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
        public string SessionId { get; set; }
        public string Language { get; set; }

    }
}

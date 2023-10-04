using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Service.Model
{
    public class VMStudent : IVM
    {

        public string RegNo { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}

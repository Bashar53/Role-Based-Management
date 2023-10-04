using RoleBased.Shared.Common;
using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model
{
    public class StudentInfo : BaseAuditableEntity, IEntity
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string  Phone { get; set; }

        public string Email { get; set; }



    }
}

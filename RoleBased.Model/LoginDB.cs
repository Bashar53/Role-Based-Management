using RoleBased.Shared.Common;
using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RoleBased.Model;

public class LoginDB : BaseAuditableEntity, IEntity
{

    public string RegNo { get; set; }
    public string Pass { get; set; }
    public string Role { get; set; }


}

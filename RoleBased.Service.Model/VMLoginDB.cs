﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Service.Model
{
    public  class VMLoginDB : IVM
    {

        public string RegNo { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
    }
}

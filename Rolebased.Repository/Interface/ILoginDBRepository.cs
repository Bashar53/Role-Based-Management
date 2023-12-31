﻿using AutoMapper;
using Rolebased.Repository.Concrete;
using RoleBased.Infrastructure.Persistence;
using RoleBased.Model;
using RoleBased.Service.Model;
using RoleBased.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolebased.Repository.Interface
{
    public interface IloginDBRepository : IRepository<LoginDB, VMLoginDB, string>     
    {
    }
}

using RoleBased.Model;
using Rolebased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RoleBased.Infrastructure.Persistence;

namespace Rolebased.Repository.Concrete
{
    public class LoginDBRepository : RepositoryBase<LoginDB, VMLoginDB, string> , IloginDBRepository
    {
        public LoginDBRepository(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }   
    }
}

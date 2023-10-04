using AutoMapper;
using Rolebased.Repository.Interface;
using RoleBased.Infrastructure.Persistence;
using RoleBased.Model;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolebased.Repository.Concrete
{
    public class StudentInfoRepository : RepositoryBase<StudentInfo, VMStudent, string>, IStudentInfoRepository
    {
        public StudentInfoRepository(RoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}

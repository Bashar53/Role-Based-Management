using AutoMapper;
using RoleBased.Model;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.Mapping
{
    public class MappingExtention:Profile
    {
        public MappingExtention() {
            CreateMap<VMStudent, StudentInfo>().ReverseMap();

        }

    }
}

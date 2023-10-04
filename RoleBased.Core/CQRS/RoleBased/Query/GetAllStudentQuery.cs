using MediatR;
using Rolebased.Repository.Interface;
using RoleBased.Model;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query;
public record GetAllStudentQuery() : IRequest<QueryResult<IEnumerable<VMStudent>>>;

public  class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, QueryResult<IEnumerable<VMStudent>>>
{
            private readonly IStudentInfoRepository _studentRepository;
        public GetAllStudentQueryHandler(IStudentInfoRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<QueryResult<IEnumerable<VMStudent>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAllAsync();

            return student switch
            {
                null => new QueryResult<IEnumerable<VMStudent>>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<IEnumerable<VMStudent>>(student, QueryResultTypeEnum.Success)
            };



        }
    }



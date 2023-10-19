using MediatR;
using Rolebased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query;

public record GetAllLoginDBQuery() : IRequest<QueryResult<IEnumerable<VMLoginDB>>>;

public class GetAllLoginDBQueryHandler : IRequestHandler<GetAllLoginDBQuery, QueryResult<IEnumerable<VMLoginDB>>>
{
    private readonly IloginDBRepository _loginRepository;   
    public GetAllLoginDBQueryHandler(IloginDBRepository loginRepository)    
    {
        _loginRepository = loginRepository;
    }
    public async Task<QueryResult<IEnumerable<VMLoginDB>>> Handle(GetAllLoginDBQuery request, CancellationToken cancellationToken)
    {
        var student = await _loginRepository.GetAllAsync();

        return student switch
        {
            null => new QueryResult<IEnumerable<VMLoginDB>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMLoginDB>>(student, QueryResultTypeEnum.Success)
        };



    }
}




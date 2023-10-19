using FluentValidation;
using MediatR;
using Rolebased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query;

public record GetAllLoginDBByIdQuery : IRequest<QueryResult<VMLoginDB>>
{
    [JsonConstructor]
    public GetAllLoginDBByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }

    public class GetAllLoginDBByIdQueryHandler : IRequestHandler<GetAllLoginDBByIdQuery, QueryResult<VMLoginDB>>
    {
        private readonly IloginDBRepository _loginRepository;
        private readonly IValidator<GetAllLoginDBByIdQuery> _validator;
        public GetAllLoginDBByIdQueryHandler(IloginDBRepository loginRepository, IValidator<GetAllLoginDBByIdQuery> validator)
        {
            _loginRepository = loginRepository;
            _validator = validator;
        }
        public async Task<QueryResult<VMLoginDB>> Handle(GetAllLoginDBByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            var login  = await _loginRepository.GetByIdAsync(request.Id);
            return login switch
            {
                null => new QueryResult<VMLoginDB>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMLoginDB>(login, QueryResultTypeEnum.Success)
            };


        }
    }



}


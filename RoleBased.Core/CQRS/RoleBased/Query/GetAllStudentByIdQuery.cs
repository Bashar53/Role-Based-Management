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

public record GetAllStudentByIdQuery :  IRequest<QueryResult<VMStudent>>
{
    [JsonConstructor]
    public GetAllStudentByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }

    public class GetAllStudentByIdQueryHandler : IRequestHandler<GetAllStudentByIdQuery, QueryResult<VMStudent>>
    {
        private readonly IStudentInfoRepository _studentRepository;
        private readonly IValidator<GetAllStudentByIdQuery> _validator;
        public GetAllStudentByIdQueryHandler(IStudentInfoRepository studentRepository, IValidator<GetAllStudentByIdQuery> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }
        public async Task<QueryResult<VMStudent>> Handle(GetAllStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            var student = await _studentRepository.GetByIdAsync(request.Id);
            return student switch
            {
                null => new QueryResult<VMStudent>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMStudent>(student, QueryResultTypeEnum.Success)
            };


        }
    }



}

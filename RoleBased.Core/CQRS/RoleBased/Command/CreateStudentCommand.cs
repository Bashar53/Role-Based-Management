using AutoMapper;
using FluentValidation;
using MediatR;
using Rolebased.Repository.Interface;
using RoleBased.Model;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command;

public record CreateStudentCommand(VMStudent student) : IRequest<CommandResult<VMStudent>>;


public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CommandResult<VMStudent>>
{
    private readonly IStudentInfoRepository _studentRepository;
    private readonly IValidator<CreateStudentCommand> _validator;
    private readonly IMapper _mapper;

    public CreateStudentCommandHandler(IStudentInfoRepository studentRepository, IValidator<CreateStudentCommand> validator, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudent>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<StudentInfo>(request.student);
        var student = await _studentRepository.InsertAsync(result);
        return student switch
        {
            null => new CommandResult<VMStudent>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudent>(student, CommandResultTypeEnum.Success)
        };

    }
}


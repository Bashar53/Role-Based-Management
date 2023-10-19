using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using Rolebased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Command;

public record CreateLoginDBCommand(VMLoginDB login) : IRequest<CommandResult<VMLoginDB>>;

public class CreateLoginDBCommandHandler : IRequestHandler<CreateLoginDBCommand, CommandResult<VMLoginDB>>
{
    private readonly IloginDBRepository _loginRepository;
    private readonly IValidator<CreateLoginDBCommand> _validator;
    private readonly IMapper _mapper;

    public CreateLoginDBCommandHandler(IloginDBRepository loginRepository, IValidator<CreateLoginDBCommand> validator, IMapper mapper)    
    {
        _loginRepository = loginRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMLoginDB>> Handle(CreateLoginDBCommand request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<LoginDB>(request.login);
        var login = await _loginRepository.InsertAsync(result);
        return login switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDB>(login, CommandResultTypeEnum.Success)
        };

    }
}
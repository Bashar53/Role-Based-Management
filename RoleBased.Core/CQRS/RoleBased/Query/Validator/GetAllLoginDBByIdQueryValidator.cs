using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query.Validator;

public class GettAllLoginDBByIdQueryValidator : AbstractValidator<GetAllLoginDBByIdQuery>
{
    public GettAllLoginDBByIdQueryValidator()   
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
    }

}



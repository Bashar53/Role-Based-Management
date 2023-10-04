using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBased.Query.Validator;

public  class GettAllStudentByIdQueryValidator : AbstractValidator<GetAllStudentByIdQuery>
{
    public GettAllStudentByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
    }

}

using Csharp.CRUD.Application.Extensions;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Domain;
using FluentValidation;

namespace Csharp.CRUD.Application.Validators.Customers;

public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
{

    public CreateCustomerValidator()
    {

        RuleFor(customer => customer.CreateCustomerDto.PhoneNumber).Must(i => i.IsValidPhoneNumber())
            .WithMessage(Constants.PhoneNumberInvalidMessage);
    }
    
}
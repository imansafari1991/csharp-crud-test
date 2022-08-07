using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Extensions;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Domain;
using FluentValidation;

namespace Csharp.CRUD.Application.Validators.Customers;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{

    public UpdateCustomerValidator(ICustomerRepository _customerRepository)
    {

        RuleFor(customer => customer.UpdateCustomerDto.PhoneNumber).Must(i => i.IsValidPhoneNumber())
            .WithMessage(Constants.PhoneNumberInvalidMessage);
        RuleFor(customer => customer.UpdateCustomerDto.Email).Must(i => i.IsValidEmail())
            .WithMessage(Constants.InCorrectEmailFormat);
        RuleFor(customer => customer.UpdateCustomerDto.FirstName).NotNull()
            .WithMessage(Constants.FirstNameCannotBeNull);
        RuleFor(customer => customer.UpdateCustomerDto.LastName).NotNull()
            .WithMessage(Constants.LastNameCannotBeNull);
        RuleFor(customer => customer.UpdateCustomerDto.Email).NotNull()
            .WithMessage(Constants.EmailCannotBeNull);
        RuleFor(customer => customer.UpdateCustomerDto.BankAccountAddress).MaximumLength(15)
            .WithMessage(Constants.BankAccountMax);
        RuleFor(customer => customer.UpdateCustomerDto.BankAccountAddress).MinimumLength(5)
            .WithMessage(Constants.BankAccountMin);
    }
    
}
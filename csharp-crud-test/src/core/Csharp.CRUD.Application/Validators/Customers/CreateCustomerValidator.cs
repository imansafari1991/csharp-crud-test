using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Extensions;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Domain;
using FluentValidation;

namespace Csharp.CRUD.Application.Validators.Customers;

public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
{

    public CreateCustomerValidator(ICustomerRepository _customerRepository)
    {

        RuleFor(customer => customer.CreateCustomerDto.PhoneNumber).Must(i => i.IsValidPhoneNumber())
            .WithMessage(Constants.PhoneNumberInvalidMessage);
        RuleFor(customer => customer.CreateCustomerDto.Email).Must(i => i.IsValidEmail())
            .WithMessage(Constants.InCorrectEmailFormat);
        RuleFor(customer => customer.CreateCustomerDto.Email).Must(i => !_customerRepository.IsExists(i))
            .WithMessage(Constants.DuplicateEmailAddress);
        RuleFor(customer => customer.CreateCustomerDto.FirstName).NotNull()
            .WithMessage(Constants.FirstNameCannotBeNull);
        RuleFor(customer => customer.CreateCustomerDto.LastName).NotNull()
            .WithMessage(Constants.LastNameCannotBeNull);
        RuleFor(customer => customer.CreateCustomerDto.Email).NotNull()
            .WithMessage(Constants.EmailCannotBeNull);
        RuleFor(customer => customer.CreateCustomerDto.BankAccountAddress).MaximumLength(15)
            .WithMessage(Constants.BankAccountMax);
        RuleFor(customer => customer.CreateCustomerDto.BankAccountAddress).MinimumLength(5)
            .WithMessage(Constants.BankAccountMin);
    }
    
}
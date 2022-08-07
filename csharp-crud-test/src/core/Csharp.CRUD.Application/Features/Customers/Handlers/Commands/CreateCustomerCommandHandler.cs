using AutoMapper;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Application.Responses.Base;
using Csharp.CRUD.Application.Validators.Customers;
using Csharp.CRUD.Domain;
using FluentValidation.Results;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<CommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request.CreateCustomerDto);
        var results = new CreateCustomerValidator(_customerRepository).Validate(request);
        if (!results.IsValid)
        {
            return new HasError(results);
        }
        if (!_customerRepository.IsExists(customer))
        {
            await _customerRepository.Add(customer);
        }
        else
        {
            return new HasError(new ValidationResult() { Errors = new List<ValidationFailure>() { new() { ErrorMessage = "This user is allready exists!" } } });
        }


        return new Success()
        {
            Data = customer,
            Id = customer.Id

        };
    }
}
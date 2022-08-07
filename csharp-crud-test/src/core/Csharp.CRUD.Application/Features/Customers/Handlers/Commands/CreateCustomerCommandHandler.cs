using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {



        throw new NotImplementedException();
    }
}
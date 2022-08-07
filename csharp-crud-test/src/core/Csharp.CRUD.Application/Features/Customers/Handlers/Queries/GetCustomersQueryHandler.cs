using AutoMapper;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Application.Features.Customers.Requests.Queries;
using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Queries;

public class GetCustomersQueryHandler:IRequestHandler<GetCustomersQuery,CommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CommandResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers =await _customerRepository.GetAll();

        var res = _mapper.Map<List<GetCustomerDto>>(customers);


        return new Success()
        {
            Data = res
        };
        
    }
}
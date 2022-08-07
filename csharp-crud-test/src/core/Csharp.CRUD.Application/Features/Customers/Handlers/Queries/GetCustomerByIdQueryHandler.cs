using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Features.Customers.Requests.Queries;
using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id);
            if (customer == null)
            {
                return new ResponseNotFound();
            }

            return new Success()
            {
                Data = customer
            };




        }
    }
}

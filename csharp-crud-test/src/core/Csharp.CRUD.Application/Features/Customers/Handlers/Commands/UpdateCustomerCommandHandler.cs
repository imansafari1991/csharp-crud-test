using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Application.Responses.Base;
using Csharp.CRUD.Application.Validators.Customers;
using Csharp.CRUD.Domain;
using FluentValidation.Results;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var results = new UpdateCustomerValidator(_customerRepository).Validate(request);
            if (!results.IsValid)
            {
                return new HasError(results);
            }




            var customer = await _customerRepository.Get(request.UpdateCustomerDto.Id);

            if (customer == null)
            {
                return new ResponseNotFound();
            }
            _mapper.Map(request.UpdateCustomerDto,customer );
            await _customerRepository.Update(customer);
            return new Success()
            {
                Data = customer
            };

        }
    }
}

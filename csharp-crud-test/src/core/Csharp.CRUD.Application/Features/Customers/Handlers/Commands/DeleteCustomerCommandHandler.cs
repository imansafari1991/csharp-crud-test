using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.CRUD.Application.Contracts.Persistence;
using Csharp.CRUD.Application.Features.Customers.Requests.Commands;
using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Handlers.Commands
{
    public class DeleteCustomerCommandHandler:IRequestHandler<DeleteCustomerCommand,CommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =await _customerRepository.Get(request.Id);
            if (customer == null)
            {
                return new ResponseNotFound();
            }

            await _customerRepository.Delete(customer);

            return new Success()
            {
                Id = request.Id
            };

        }
    }
}

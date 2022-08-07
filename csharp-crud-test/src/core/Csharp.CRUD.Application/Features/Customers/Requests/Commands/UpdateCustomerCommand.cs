using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Commands;

public class UpdateCustomerCommand:IRequest<CommandResponse>
{
    public UpdateCustomerDto UpdateCustomerDto { get; set; }
}
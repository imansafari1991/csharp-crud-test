using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Commands;

public class DeleteCustomerCommand:IRequest<CommandResponse>
{
    public int Id { get; set; }
}
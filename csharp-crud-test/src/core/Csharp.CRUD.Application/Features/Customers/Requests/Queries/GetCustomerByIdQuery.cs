using Csharp.CRUD.Application.Responses.Base;
using MediatR;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Queries;

public class GetCustomerByIdQuery:IRequest<CommandResponse>
{
    public int Id { get; set; }
}
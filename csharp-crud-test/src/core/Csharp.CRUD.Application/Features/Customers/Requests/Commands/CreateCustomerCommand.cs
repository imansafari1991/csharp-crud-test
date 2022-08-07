using MediatR;
using System.ComponentModel.DataAnnotations;
using Csharp.CRUD.Application.DTOs.Customers;
using Csharp.CRUD.Application.Responses.Base;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Commands;

public class CreateCustomerCommand : IRequest<CommandResponse>
{
    public CreateCustomerDto CreateCustomerDto { get; set; }
}
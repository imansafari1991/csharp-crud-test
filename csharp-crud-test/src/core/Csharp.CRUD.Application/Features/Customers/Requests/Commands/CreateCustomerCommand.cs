using MediatR;
using System.ComponentModel.DataAnnotations;
using Csharp.CRUD.Application.DTOs.Customers;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Commands;

public class CreateCustomerCommand : IRequest<Unit>
{
    public CreateCustomerDto CreateCustomerDto { get; set; }
}
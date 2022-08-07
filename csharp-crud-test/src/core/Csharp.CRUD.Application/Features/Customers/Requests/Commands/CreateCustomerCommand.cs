using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Csharp.CRUD.Application.Features.Customers.Requests.Commands;

public class CreateCustomerCommand : IRequest<Unit>
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public DateTime DateOfBirth { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string BankAccountAddress { get; set; }
}
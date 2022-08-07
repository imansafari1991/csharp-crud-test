using System.ComponentModel.DataAnnotations;

namespace Csharp.CRUD.Domain;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateTime { get; set; }
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public string BankAccountAddress { get; set; }
}
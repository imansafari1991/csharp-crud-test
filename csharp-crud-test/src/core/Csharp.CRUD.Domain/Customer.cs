using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Csharp.CRUD.Domain;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string BankAccountAddress { get; set; }

    public Customer( string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountAddress)
    {
      
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountAddress = bankAccountAddress;
    }
   

  

}
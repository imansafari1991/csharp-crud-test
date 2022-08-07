using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Csharp.CRUD.Domain;

public class Customer
{
    public string FirstName { get;private set; }
    public string LastName { get;private set; }
    public DateTime DateOfBirth { get;private set; }
    public string PhoneNumber { get; private set; }
    [EmailAddress]
    public string Email { get; private set; }

    public string BankAccountAddress { get; set; }

    private Customer()
    {

    }
    public static Customer CreateInstance()
    {
        return new Customer();
    }

    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        LastName=lastName;
    }

    public void SetDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth=dateOfBirth;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber=phoneNumber;
    }
    public void SetEmail(string email)
    {
        Email = email;
    }
    public void SetBankAccountAddress(string bankAccountAddress)
    {
        BankAccountAddress = bankAccountAddress;
    }

}
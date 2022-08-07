namespace Csharp.CRUD.Domain;

public static class Constants
{
    public const string PhoneNumberInvalidMessage = "Phone number length cannot be more than 15.";
    public const string InCorrectEmailFormat = "You have used incorrect email format.";
    public const string DuplicateEmailAddress = "Your email is allready exists.";

    public const string FirstNameCannotBeNull = "Firstname Cannot Be Null.";
    public const string LastNameCannotBeNull = "LastName Cannot Be Null.";
    public const string EmailCannotBeNull = "Email Cannot Be Null.";

    public const string BankAccountMax = "Bank Account Number Cannot exceed more than 15 characters.";
    public const string BankAccountMin = "Bank Account Number Cannot less than 5 characters.";





    public const string DateOfBirthInvalid = "You cannot born after today!";

    public const string InvalidPhoneNumberRegion = "Missing or invalid default region.";

    public const string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                        + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
}
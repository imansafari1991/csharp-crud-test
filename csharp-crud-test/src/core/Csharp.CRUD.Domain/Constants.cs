namespace Csharp.CRUD.Domain;

public static class Constants
{
    public const string PhoneNumberInvalidMessage = "Phone number length cannot be more than 15";
    public const string InCorrectEmailFormat = "You have used incorrect email format";

    public const string DateOfBirthInvalid = "You cannot born after today!";



    public const string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                        + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
}
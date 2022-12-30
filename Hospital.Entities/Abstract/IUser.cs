using Hospital.Core.Enums;

namespace Hospital.Entities.Abstract
{
    public interface IUser
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        Status Status { get; set; }

    }
}

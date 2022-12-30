using Hospital.Core.Entities.Abstract;
using Hospital.Core.Enums;
using Hospital.Entities.Abstract;

namespace Hospital.Entities.Concrete
{
    public class Admin : IUser,IBaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime? UpdatedDate {  get; set; }
        public DateTime? DeletedDate {  get; set; }
    }
}

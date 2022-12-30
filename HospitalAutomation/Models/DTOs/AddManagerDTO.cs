using Hospital.Core.Enums;

namespace HospitalAutomation.Models.DTOs
{
    public class AddManagerDTO
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Status Status { get; set; }=Status.Active;
        public decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;

    }
}

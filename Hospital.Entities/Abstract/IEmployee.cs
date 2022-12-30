namespace Hospital.Entities.Abstract
{
    public interface IEmployee
    {
        string IdentityNumber { get; set; }
        decimal Salary { get; set; }
    }
}

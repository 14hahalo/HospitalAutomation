using Hospital.Core.Enums;

namespace Hospital.Core.Entities.Abstract
{
    public interface IBaseEntity
    {
        Status Status { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}

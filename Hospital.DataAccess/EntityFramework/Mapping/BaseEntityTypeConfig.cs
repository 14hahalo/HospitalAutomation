using Hospital.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.EntityFramework.Mapping
{
    public class BaseEntityTypeConfig<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}

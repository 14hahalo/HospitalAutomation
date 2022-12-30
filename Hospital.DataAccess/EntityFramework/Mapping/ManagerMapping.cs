using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.EntityFramework.Mapping
{
    public class ManagerMapping : BaseEntityTypeConfig<Manager>
    {
        public override void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.HasMany(x => x.Personnels)
                .WithOne(x => x.Manager)
                .HasForeignKey(x => x.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}

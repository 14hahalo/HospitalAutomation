using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataAccess.EntityFramework.Mapping
{
    public class PersonnelMapping : BaseEntityTypeConfig<Personnel>
    {
        public override void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);
            base.Configure(builder);
        }
    }
}

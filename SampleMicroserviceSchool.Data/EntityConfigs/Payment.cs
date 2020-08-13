using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleMicroserviceSchool.Data.EntityConfigs
{
    public class Payment : IEntityTypeConfiguration<Entities.Payment>
    {
        public void Configure(EntityTypeBuilder<Entities.Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PayAmount).IsRequired();
            builder.HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId).IsRequired();
            builder.HasOne(x => x.Course).WithMany().HasForeignKey(x => x.CourseId).IsRequired();
        }
    }
}

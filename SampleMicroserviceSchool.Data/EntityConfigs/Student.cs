using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleMicroserviceSchool.Data.EntityConfigs
{
    public class Student : IEntityTypeConfiguration<Entities.Student>
    {
        public void Configure(EntityTypeBuilder<Entities.Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.HasOne(x => x.Course).WithMany().HasForeignKey(x => x.CourseId).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleMicroserviceSchool.Data.EntityConfigs
{
    public class Course : IEntityTypeConfiguration<Entities.Course>
    {
        public void Configure(EntityTypeBuilder<Entities.Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
        }
    }
}

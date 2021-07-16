using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(std => std.StudentSubjects)
                   .WithOne(sub => sub.student)
                   .HasForeignKey(sub => sub.studentID);

            builder.HasOne(std => std.department)
                .WithMany(dep => dep.Students)
                .HasForeignKey(dep => dep.DepartmentID);
        }
    }
}

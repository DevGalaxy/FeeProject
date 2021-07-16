using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class SubjectConfigration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasMany(S => S.StaffSubjects)
                .WithOne(S => S.subject)
                .HasForeignKey(s => s.SubjectId);

            builder.HasMany(sub => sub.StudentSubjects)
                 .WithOne(std => std.subject)
                 .HasForeignKey(std => std.subjectID);

            builder.HasOne(sub => sub.department)
                .WithMany(dep => dep.Subjects)
                .HasForeignKey(sub => sub.DepartmentID);


        }
    }
}

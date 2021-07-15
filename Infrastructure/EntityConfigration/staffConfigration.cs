using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class staffConfigration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasMany(st => st.StaffSubjects)
                .WithOne(sub => sub.Staff)
                .HasForeignKey(sub => sub.StaffId);

            builder.HasOne(S => S.position)
                .WithOne(P => P.staff)
                .HasForeignKey<Staff>(s => s.positionID);

            builder.HasOne(s => s.Department)
                .WithMany(dep => dep.Staffs)
                .HasForeignKey(s => s.DepratnemtID);
        }
    }
}

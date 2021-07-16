using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class StaffSubjectConfigration : IEntityTypeConfiguration<StaffSubjects>
    {
        public void Configure(EntityTypeBuilder<StaffSubjects> builder)
        {
            builder.HasKey(ss => ss.ID);
        }
    }
}

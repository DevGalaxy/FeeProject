using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class SubjectDepedanceConfigration : IEntityTypeConfiguration<SubjectDepedance>
    {
        public void Configure(EntityTypeBuilder<SubjectDepedance> builder)
        {
            builder.HasKey(s => new { s.SubjectID, s.DependID });

            builder.HasOne(s => s.subject)
                .WithMany(s => s.DependentOn)
                .HasForeignKey(s => s.SubjectID);

            builder.HasOne(d => d.DependOn)
                .WithMany(s => s.DepeondentAt)
                .HasForeignKey(d => d.DependID);
        }
    }
}

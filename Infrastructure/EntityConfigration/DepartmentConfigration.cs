using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigration
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(dep => dep.Head)
                .WithOne(stf => stf.Managed)
                .HasForeignKey<Department>(dep => dep.MangerID);
        }
    }
}

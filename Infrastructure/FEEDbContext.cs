using Core.Entites;
using Infrastructure.EntityConfigration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FEEDbContext : IdentityDbContext<ApplicationUser>
    {
        public FEEDbContext(DbContextOptions<FEEDbContext> ops) : base(ops)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentReport> DepartmentReports { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsSubImages> NewsSubImages { get; set; }
        public DbSet<StaffSubjects> StaffSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<SubjectDepedance> SubjectDepedances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentLab> DepartmentLabs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Page> Pages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SubjectDepedanceConfigration());

            builder.Entity<Department>()
                .HasMany(a => a.Users)
                .WithOne(b => b.Department);
            builder.Entity<StaffSubjects>()
                .HasKey(bc => new { bc.UserId, bc.SubjectId });

            builder.Entity<StaffSubjects>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.StaffSubjects)
                .HasForeignKey(bc => bc.UserId);
            builder.Entity<StaffSubjects>()
                .HasOne(bc => bc.Subject)
                .WithMany(c => c.StaffSubjects)
                .HasForeignKey(bc => bc.SubjectId);

            builder.Entity<StudentSubject>()
                .HasKey(bc => new { bc.UserId, bc.SubjectId });

            builder.Entity<StudentSubject>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.StudentSubjects)
                .HasForeignKey(bc => bc.UserId);
            builder.Entity<StudentSubject>()
                .HasOne(bc => bc.Subject)
                .WithMany(c => c.StudentSubjects)
                .HasForeignKey(bc => bc.SubjectId);

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .ToTable("Users");
            builder.Entity<IdentityRole>()
                .ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");
        }


    }
}

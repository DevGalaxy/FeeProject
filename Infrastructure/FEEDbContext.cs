using Core.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FEEDbContext:IdentityDbContext<ApplicationUser>
    {
        public FEEDbContext(DbContextOptions<FEEDbContext> ops):base(ops)
        {

        }
        public DbSet<Association> Associations   { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsSubImages> NewsSubImages { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffSubjects> StaffSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }


    }
}

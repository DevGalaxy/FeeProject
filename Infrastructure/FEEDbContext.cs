﻿using Core.Entites;
using Infrastructure.EntityConfigration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FEEDbContext : IdentityDbContext<ApplicationUser>
    {
        public FEEDbContext(DbContextOptions<FEEDbContext> ops) : base(ops)
        {

        }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsSubImages> NewsSubImages { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffSubjects> StaffSubjects { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<SubjectDepedance> subjectDepedances { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfigration());
            builder.ApplyConfiguration(new staffConfigration());
            builder.ApplyConfiguration(new StudentSubjectConfigration());
            builder.ApplyConfiguration(new StaffSubjectConfigration());
            builder.ApplyConfiguration(new SubjectDepedanceConfigration());
            builder.ApplyConfiguration(new SubjectConfigration());
            base.OnModelCreating(builder);
        }


    }
}

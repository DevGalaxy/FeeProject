using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            StaffSubjects = new HashSet<StaffSubjects>();
            StudentSubjects = new HashSet<StudentSubject>();
        }
        public string AcademicNumber { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string Image { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public virtual ICollection<StaffSubjects> StaffSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}

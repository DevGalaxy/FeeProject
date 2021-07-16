using System;
using System.Collections.Generic;

namespace Core.Entites
{
    public class Student : BaseEntity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string AcademicNumber { get; set; }
        public DateTime DataOfBirth { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
    }
}

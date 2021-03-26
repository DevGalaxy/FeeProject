using System;

namespace Core.Entites
{
    public class Student :BaseEntity
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string AcademicNumber { get; set; }
        public DateTime DataOfBirth { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

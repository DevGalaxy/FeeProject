using System.Collections.Generic;

namespace Core.Entites
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            StaffSubjects = new HashSet<StaffSubjects>();
            StudentSubjects = new HashSet<StudentSubject>();
            DependentOn = new HashSet<SubjectDepedance>();
            DepeondentAt = new HashSet<SubjectDepedance>();
        }
        public string Name { get; set; }
        public string CodeEN { get; set; }
        public string CodeAR { get; set; }
        public int numOfHours { get; set; }
        public int maxDegree { get; set; }
        public int minDegree { get; set; }
        public string content { get; set; }
        public bool Enabled { get; set; }


        // the relations members
        public int DepartmentID { get; set; }
        public Department department { get; set; }
        public virtual ICollection<StaffSubjects> StaffSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        //the subjects that the subject depend on
        public virtual ICollection<SubjectDepedance> DependentOn { get; set; }
        // the subjects that depend on the subject
        public virtual ICollection<SubjectDepedance> DepeondentAt { get; set; }
    }
}

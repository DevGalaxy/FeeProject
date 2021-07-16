using System.Collections.Generic;

namespace Core.Entites
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Subjects = new HashSet<Subject>();
            Students = new HashSet<Student>();
            Staffs = new HashSet<Staff>();
            DepartmentLabs = new HashSet<DepartmentLab>();
            DepartmentReports = new HashSet<DepartmentReport>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Massage { get; set; }
        public string Goals { get; set; }
        public string HeadSpeech { get; set; }

        public virtual ICollection<DepartmentReport> DepartmentReports { get; set; }
        public virtual ICollection<DepartmentLab> DepartmentLabs { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public int MangerID { get; set; }

        public Staff Head { get; set; }
    }
}

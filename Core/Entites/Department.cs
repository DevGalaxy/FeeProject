using System.Collections.Generic;

namespace Core.Entites
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Subjects = new HashSet<Subject>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public int MangerID { get; set; }

        public Staff Head { get; set; }
    }
}

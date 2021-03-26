using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            StaffSubjects = new HashSet<StaffSubjects>();
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public int TotalHours { get; set; }
        public virtual ICollection<StaffSubjects> StaffSubjects { get; set; }
    }
}

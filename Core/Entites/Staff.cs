using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class Staff:BaseEntity
    {
        public Staff()
        {
            StaffSubjects = new HashSet<StaffSubjects>();
        }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ScientificDegree { get; set; }
        public virtual ICollection<StaffSubjects> StaffSubjects { get; set; }
    }
}

using System.Collections.Generic;

namespace Core.Entites
{
    public class Staff : BaseEntity
    {
        public Staff()
        {
            StaffSubjects = new HashSet<StaffSubjects>();
        }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ScientificDegree { get; set; }
        public int? positionID { get; set; }
        public Position position { get; set; }
        public int? DepratnemtID { get; set; }
        public Department Department { get; set; }
        public Department Managed { get; set; }
        public virtual ICollection<StaffSubjects> StaffSubjects { get; set; }
    }
}

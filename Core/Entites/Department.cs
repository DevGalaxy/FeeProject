using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Subjects = new HashSet<Subject>();
            Users = new HashSet<ApplicationUser>();
            DepartmentLabs = new HashSet<DepartmentLab>();
            DepartmentReports = new HashSet<DepartmentReport>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Massage { get; set; }
        public string Goals { get; set; }
        public string HeadSpeech { get; set; }
        public string Image { get; set; }
        public virtual ICollection<DepartmentReport> DepartmentReports { get; set; }
        public virtual ICollection<DepartmentLab> DepartmentLabs { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public string HeadId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites
{
    public class StaffSubjects:BaseEntity
    {
        public int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Subject subject { get; set; }
        public int StaffId { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public int Year { get; set; }
    }
}

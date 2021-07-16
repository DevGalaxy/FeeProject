using System;

namespace Core.Entites
{
    public class StaffSubjects : BaseEntity
    {
        public int ID { get; set; }
        public int AcadimicYear { get; set; }
        public string location { get; set; }
        public SessionType sessionType { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string weekDay { get; set; }
        public DateTime examDay { get; set; }

        public int SubjectId { get; set; }

        public Subject subject { get; set; }

        public int StaffId { get; set; }

        public Staff Staff { get; set; }

    }
    public enum SessionType { lecture, section, lap }
}

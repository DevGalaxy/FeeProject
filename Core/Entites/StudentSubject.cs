namespace Core.Entites
{
    public class StudentSubject
    {
        public int? degree { get; set; }
        public states state { get; set; }
        public int AcademicYear { get; set; }

        public int studentID { get; set; }

        public Student student { get; set; }

        public int subjectID { get; set; }

        public Subject subject { get; set; }



    }
    public enum states { draft, commit }
}

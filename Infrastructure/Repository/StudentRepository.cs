using Core.Entites;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly FEEDbContext _db;
        public StudentRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }

        public ICollection<Subject> AllSudetedSubjects(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> subjects = new List<Subject>();
                foreach (StudentSubject item in student.StudentSubjects)
                {
                    subjects.Add(item.subject);
                }
                return subjects;
            }
            return null;
        }

        public ICollection<StudentSubject> Degrees(int id)
        {

            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                return student.StudentSubjects.Where(s => s.degree != null).ToList();

            }
            return null;

        }

        public ICollection<Subject> DraftSubjects(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> Draft = new List<Subject>();
                foreach (StudentSubject subject in student.StudentSubjects)
                {
                    if (subject.state == states.draft)
                    {
                        Draft.Add(subject.subject);
                    }
                }
                return Draft;
            }
            return null;
        }

        public ICollection<Subject> EnabledSubjects(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> studedSubjects = AllSudetedSubjects(id).ToList();
                List<Subject> AllSubjects = _db.Subjects.ToList();
                List<Subject> Enabled = new List<Subject>();
                foreach (Subject subject in AllSubjects)
                {
                    if (!studedSubjects.Exists(s => s.Id == subject.Id) && subject.Enabled == true)
                    {
                        bool prerequest = true;
                        foreach (SubjectDepedance depend in subject.DependentOn)
                        {
                            if (!studedSubjects.Exists(s => s.Id == depend.DependID))
                            {
                                prerequest = false; break;
                            }
                        }
                        if (prerequest == true) { Enabled.Add(subject); }
                    }
                }
                return Enabled;
            }
            return null;
        }




        public ICollection<StaffSubjects> schedules(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> subjects = SutudingSubjects(id).ToList();
                List<StaffSubjects> schedul = new List<StaffSubjects>();
                foreach (Subject subject in subjects)
                {
                    schedul.AddRange(subject.StaffSubjects);
                }
                return schedul;
            }
            return null;
        }

        public int StudentsNumber()
        {
            return _db.students.Count();
        }

        public ICollection<Subject> SutudingSubjects(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> subjects = new List<Subject>();
                foreach (StudentSubject item in student.StudentSubjects)
                {
                    if (item.degree == null)
                        subjects.Add(item.subject);
                }
                return subjects;
            }
            return null;
        }
    }
}

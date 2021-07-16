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

        public ICollection<Subject> degrees(int id)
        {

            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> subjects = new List<Subject>();
                foreach (StudentSubject item in student.StudentSubjects)
                {
                    if (item.degree != null)
                        subjects.Add(item.subject);
                }
                return subjects;
            }
            return null;

        }

        public ICollection<Subject> enabledsubjects(int id)
        {
            Student student = _db.students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                List<Subject> studedSubjects = AllSudetedSubjects(id).ToList();
                List<Subject> AllSubjects = _db.Subjects.ToList();
                List<Subject> Enabled = new List<Subject>();
                foreach (Subject subject in AllSubjects)
                {
                    if (!studedSubjects.Exists(s => s.Id == subject.Id))
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

        public ICollection<Subject> sutudingsubjects(int id)
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

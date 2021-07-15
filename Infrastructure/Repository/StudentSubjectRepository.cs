using Core.Entites;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class StudentSubjectRepository : Repository<StudentSubject>, IStudentSubjectRepository
    {
        private readonly FEEDbContext _db;
        public StudentSubjectRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<Subject> GetEnabeledSubjects(int studentID)
        {
            var subjects = _db.studentSubjects.Where(s => s.studentID == studentID).Select(s => s.subject).ToList();

            //un finnished
            return subjects;
        }
    }
}

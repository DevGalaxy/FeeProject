using Core.Entites;
using Core.IRepository;

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

        public void closeRegistration()
        {
            var subjects = _db.Subjects;
            foreach (Subject subject in subjects)
            {
                subject.Enabled = false;
            }
            var regesteredSubjects = _db.studentSubjects;
            foreach (StudentSubject subject in regesteredSubjects)
            {
                if (subject.state == states.draft)
                {
                    subject.state = states.commit;
                }
            }
        }
    }
}

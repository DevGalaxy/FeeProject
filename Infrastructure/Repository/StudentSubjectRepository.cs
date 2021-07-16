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


    }
}

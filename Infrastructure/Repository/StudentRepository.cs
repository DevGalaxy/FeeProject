using Core.Entites;
using Core.IRepository;

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
    }
}

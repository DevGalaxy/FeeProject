using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly FEEDbContext _db;
        public SubjectRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

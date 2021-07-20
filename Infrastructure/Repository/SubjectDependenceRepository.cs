using Core.Entites;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SubjectDependenceRepository : Repository<SubjectDepedance>, ISubjectDepedance
    {
        private readonly FEEDbContext _db;
        public SubjectDependenceRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }


    }
}

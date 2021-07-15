using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class StaffSubjectsRepository : Repository<StaffSubjects>, IStaffSubjectsRepository
    {
        private readonly FEEDbContext _db;
        public StaffSubjectsRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

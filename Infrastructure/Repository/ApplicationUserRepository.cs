using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly FEEDbContext _db;
        public ApplicationUserRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

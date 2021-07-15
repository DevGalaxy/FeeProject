using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class AssociationRepository : Repository<Association>, IAssociationRepository
    {
        private readonly FEEDbContext _db;
        public AssociationRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class PositonRepository : Repository<Position>, IPosition
    {

        private readonly FEEDbContext _db;
        public PositonRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class MainBarRepository : Repository<MainBar>, IMainBarRepository
    {
        private readonly FEEDbContext _db;
        public MainBarRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

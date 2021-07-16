using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly FEEDbContext _db;
        public NewsRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

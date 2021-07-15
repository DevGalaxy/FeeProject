using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class NewsSubImagesRepository : Repository<NewsSubImages>, INewsSubImagesRepository
    {
        private readonly FEEDbContext _db;
        public NewsSubImagesRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

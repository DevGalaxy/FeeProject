using Core.Entites;
using Core.IRepository;

namespace Infrastructure.Repository
{
    public class EventsRepository : Repository<Events>, IEventsRepository
    {
        private readonly FEEDbContext _db;
        public EventsRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

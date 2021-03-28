using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class EventsRepository : Repository<Events> , IEventsRepository
    {
        private readonly FEEDbContext _db;
        public EventsRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

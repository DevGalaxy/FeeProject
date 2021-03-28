using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class NewsRepository : Repository<News> , INewsRepository
    {
        private readonly FEEDbContext _db;
        public NewsRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

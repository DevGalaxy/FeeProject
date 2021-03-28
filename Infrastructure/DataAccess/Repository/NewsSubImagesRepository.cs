using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class NewsSubImagesRepository : Repository<NewsSubImages> , INewsSubImagesRepository
    {
        private readonly FEEDbContext _db;
        public NewsSubImagesRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

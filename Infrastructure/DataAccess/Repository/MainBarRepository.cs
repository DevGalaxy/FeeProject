using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class MainBarRepository : Repository<MainBar> , IMainBarRepository
    {
        private readonly FEEDbContext _db;
        public MainBarRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

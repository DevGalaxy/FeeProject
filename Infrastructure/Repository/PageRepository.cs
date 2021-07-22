using Core.Entites;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class PageRepository : Repository<Page>, IPageRepository
    {
        private readonly FEEDbContext _db;
        public PageRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
        public override IEnumerable<Page> GetAll(Expression<Func<Page, bool>> filter = null, Func<IQueryable<Page>, IOrderedQueryable<Page>> OrdredBy = null, string includedPropperties = null)
        {
            return _db.Pages.Include(x => x.QuickLinks).Include(x => x.MainBar).ToList();
        }
        
        public override Page Get(int id)
        {
            return _db.Pages.Where(x => x.Id == id).Include(x => x.QuickLinks).Include(x => x.MainBar).FirstOrDefault();
        }
       
    }
}

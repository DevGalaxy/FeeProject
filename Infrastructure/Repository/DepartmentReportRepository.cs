using Core.Entites;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class DepartmentReportRepository : Repository<DepartmentReport>, IDepartmentReport
    {
        private readonly FEEDbContext _db;
        public DepartmentReportRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
        public override DepartmentReport Get(int id)
        {
            return _db.DepartmentReports.Where(x => x.Id == id).Include(x => x.department).FirstOrDefault();
        }
        public override IEnumerable<DepartmentReport> GetAll(Expression<Func<DepartmentReport, bool>> filter = null, Func<IQueryable<DepartmentReport>, IOrderedQueryable<DepartmentReport>> OrdredBy = null, string includedPropperties = null)
        {
            return _db.DepartmentReports.Include(x => x.department).ToList();
        }
    }
}

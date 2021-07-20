using Core.Entites;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class DepartmentLabRepository : Repository<DepartmentLab>, IDepartmentLapRepository
    {
        private readonly FEEDbContext _db;
        public DepartmentLabRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
        public override DepartmentLab Get(int id)
        {
            return _db.DepartmentLabs.Where(x => x.Id == id).Include(x => x.department).FirstOrDefault();
        }
        public override IEnumerable<DepartmentLab> GetAll(Expression<Func<DepartmentLab, bool>> filter = null, Func<IQueryable<DepartmentLab>, IOrderedQueryable<DepartmentLab>> OrdredBy = null, string includedPropperties = null)
        {
            return _db.DepartmentLabs.Include(x => x.department).ToList();
        }
    }
}
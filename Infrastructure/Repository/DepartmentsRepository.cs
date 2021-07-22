using Core.Entites;
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repository
{
    public class DepartmentsRepository : Repository<Department>, IDepartmentsRepository
    {
        private readonly FEEDbContext _db;
        public DepartmentsRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }
        public override Department Get(int id)
        {
            return _db
                    .Departments
                    .Where(x => x.Id == id)
                    .Include(x => x.DepartmentLabs)
                    .Include(x => x.DepartmentReports)
                    .FirstOrDefault();
        }
        public override IEnumerable<Department> GetAll(Expression<Func<Department, bool>> filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>> OrdredBy = null, string includedPropperties = null)
        {
            return _db
                    .Departments
                    .Include(x => x.DepartmentLabs)
                    .Include(x => x.DepartmentReports)
                    .ToList();
        }
    }
}
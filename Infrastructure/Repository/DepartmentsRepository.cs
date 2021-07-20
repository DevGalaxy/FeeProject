using Core.Entites;
using Core.IRepository;
using System;
using System.Collections.Generic;
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
    }
}
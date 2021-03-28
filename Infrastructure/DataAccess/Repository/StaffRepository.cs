using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class StaffRepository : Repository<Staff> , IStaffRepository
    {
        private readonly FEEDbContext _db;
        public StaffRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

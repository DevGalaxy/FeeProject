using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class StaffSubjectsRepository : Repository<StaffSubjects> , IStaffSubjectsRepository
    {
        private readonly FEEDbContext _db;
        public StaffSubjectsRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

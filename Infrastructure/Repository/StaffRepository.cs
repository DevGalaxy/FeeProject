using Core.Entites;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private readonly FEEDbContext _db;
        public StaffRepository(FEEDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<Staff> GetstaffByDepartment(int DepartmentID)
        {
            var staffs = _db.Staff.Where(s => s.DepratnemtID == DepartmentID).ToList();
            return staffs;
        }
    }
}

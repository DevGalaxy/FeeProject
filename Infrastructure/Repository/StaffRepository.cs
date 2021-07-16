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
            List<Staff> staffs = _db.Staff.Where(s => s.DepratnemtID == DepartmentID).ToList();
            return staffs;
        }

        public IEnumerable<Staff> GetstaffByPositon(string position)
        {
            List<Staff> staffs = _db.Staff.Where(s => s.position.Name.Contains(position)).ToList();
            return staffs;
        }

        public IEnumerable<StaffSubjects> schedules(int staffid)
        {
            Staff staff = _db.Staff.FirstOrDefault(s => s.Id == staffid);
            return staff.StaffSubjects.ToList();
        }

        public IEnumerable<Staff> searchByName(string name)
        {
            List<Staff> staffs = _db.Staff.Where(s => s.Name.Contains(name)).ToList();
            return staffs;
        }

        public int staffNumber()
        {
            return _db.Staff.Count();
        }
    }
}

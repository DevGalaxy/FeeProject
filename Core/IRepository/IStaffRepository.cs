using Core.Entites;
using System.Collections.Generic;

namespace Core.IRepository
{
    public interface IStaffRepository : IRepository<Staff>
    {
        IEnumerable<Staff> GetstaffByDepartment(int DepartmentID);
    }
}

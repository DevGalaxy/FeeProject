using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FEEWebApp.Controllers
{
    public class StaffController : BaseController<IStaffRepository, Staff>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public StaffController(IStaffRepository staffRepository, IUniteOfWork uniteOfWork)
            : base(staffRepository, uniteOfWork)
        {

            _uniteOfWork = uniteOfWork;
            _staffRepository = staffRepository;
        }

        [HttpGet("searchByName")]
        public IEnumerable<Staff> searchByName(string name)
        {
            return _staffRepository.searchByName(name);
        }

        [HttpGet("GetstaffByDepartment")]
        public IEnumerable<Staff> GetstaffByDepartment(int DepartmentID)
        {
            return _staffRepository.GetstaffByDepartment(DepartmentID);
        }
        [HttpGet("GetstaffByPositon")]
        public IEnumerable<Staff> GetstaffByPositon(string position)
        {
            return _staffRepository.GetstaffByPositon(position);
        }
        [HttpGet("schedules")]
        public IEnumerable<StaffSubjects> schedules(int staffid)
        {
            return _staffRepository.schedules(staffid);
        }

        [HttpGet("staffNumber")]
        public int staffNumber()
        {
            return _staffRepository.staffNumber();
        }

    }
}

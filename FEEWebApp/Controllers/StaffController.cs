using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}

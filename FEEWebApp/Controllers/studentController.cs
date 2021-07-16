using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : BaseController<IStudentRepository, Student>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public studentController(IStudentRepository StudentRepository, IUniteOfWork uniteOfWork)
            : base(StudentRepository, uniteOfWork)
        {

            _uniteOfWork = uniteOfWork;
            _StudentRepository = StudentRepository;
        }
    }
}

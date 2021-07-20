using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : BaseController<IStudentSubjectRepository, StudentSubject>
    {
        private readonly IStudentSubjectRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public StudentSubjectsController(IUniteOfWork uniteOfWork, IStudentSubjectRepository repo)
            : base(repo, uniteOfWork)
        {
            _repo = repo;
            _uniteOfWork = uniteOfWork;
        }
        [HttpPost("closeRegistration")]
        public void closeRegistration()
        {
            _repo.closeRegistration();
        }
    }
}


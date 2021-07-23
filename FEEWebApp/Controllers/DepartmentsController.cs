using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    public class DepartmentsController : BaseController<IDepartmentsRepository, Department>
    {
        private readonly IDepartmentsRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentsController(IUniteOfWork uniteOfWork, IDepartmentsRepository repo, IHttpContextAccessor httpContextAccessor)
          : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
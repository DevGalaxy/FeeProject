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

        public DepartmentsController(IUniteOfWork uniteOfWork, IDepartmentsRepository repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
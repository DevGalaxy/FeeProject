using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;

namespace FEEWebApp.Controllers
{
    public class DepartmentReportController : BaseController<IDepartmentReport, DepartmentReport>
    {
        private readonly IDepartmentReport _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentReportController(IUniteOfWork uniteOfWork, IDepartmentReport repo, IHttpContextAccessor httpContextAccessor)
             : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
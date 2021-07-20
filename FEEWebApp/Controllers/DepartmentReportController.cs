using Core.Entites;
using Core.IRepository;

namespace FEEWebApp.Controllers
{
    public class DepartmentReportController : BaseController<IDepartmentReport, DepartmentReport>
    {
        private readonly IDepartmentReport _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public DepartmentReportController(IUniteOfWork uniteOfWork, IDepartmentReport repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
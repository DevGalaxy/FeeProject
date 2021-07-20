using Core.Entites;
using Core.IRepository;

namespace FEEWebApp.Controllers
{
    public class DepartmentLapController : BaseController<IDepartmentLapRepository, DepartmentLab>
    {
        private readonly IDepartmentLapRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public DepartmentLapController(IUniteOfWork uniteOfWork, IDepartmentLapRepository repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
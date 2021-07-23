using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;

namespace FEEWebApp.Controllers
{
    public class DepartmentLapController : BaseController<IDepartmentLapRepository, DepartmentLab>
    {
        private readonly IDepartmentLapRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentLapController(IUniteOfWork uniteOfWork, IDepartmentLapRepository repo, IHttpContextAccessor httpContextAccessor)
            : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
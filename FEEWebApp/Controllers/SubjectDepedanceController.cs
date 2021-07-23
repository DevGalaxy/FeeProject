using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;

namespace FEEWebApp.Controllers
{
    public class SubjectDepedanceController : BaseController<ISubjectDepedance, SubjectDepedance>
    {
        private readonly ISubjectDepedance _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubjectDepedanceController(IUniteOfWork uniteOfWork, ISubjectDepedance repo, IHttpContextAccessor httpContextAccessor)
            : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
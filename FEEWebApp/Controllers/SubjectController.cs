using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;

namespace FEEWebApp.Controllers
{
    public class SubjectController : BaseController<ISubjectRepository, Subject>
    {
        private readonly ISubjectRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubjectController(IUniteOfWork uniteOfWork, ISubjectRepository repo, IHttpContextAccessor httpContextAccessor)
            : base(repo, uniteOfWork,httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
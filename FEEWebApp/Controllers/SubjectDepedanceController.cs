using Core.Entites;
using Core.IRepository;

namespace FEEWebApp.Controllers
{
    public class SubjectDepedanceController : BaseController<ISubjectDepedance, SubjectDepedance>
    {
        private readonly ISubjectDepedance _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public SubjectDepedanceController(IUniteOfWork uniteOfWork, ISubjectDepedance repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
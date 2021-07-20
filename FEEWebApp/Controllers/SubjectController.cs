using Core.Entites;
using Core.IRepository;

namespace FEEWebApp.Controllers
{
    public class SubjectController : BaseController<ISubjectRepository, Subject>
    {
        private readonly ISubjectRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public SubjectController(IUniteOfWork uniteOfWork, ISubjectRepository repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
using Core.Entites;
using Core.IRepository;

namespace FEEWebApp.Controllers
{
    public class StaffSubjectsController : BaseController<IStaffSubjectsRepository, StaffSubjects>
    {
        private readonly IStaffSubjectsRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public StaffSubjectsController(IUniteOfWork uniteOfWork, IStaffSubjectsRepository repo)
            : base(repo, uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
        }
    }
}
using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociationsController : BaseController<IAssociationRepository, Association>
    {
        private readonly IAssociationRepository associationRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public AssociationsController(IAssociationRepository associationRepository, IUniteOfWork uniteOfWork)
            : base(associationRepository, uniteOfWork)
        {

            _uniteOfWork = uniteOfWork;
            this.associationRepository = associationRepository;
        }
    }
}

using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
  
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

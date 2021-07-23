using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    public class MainBarController : BaseController<IMainBarRepository, MainBar>
    {
        private readonly IMainBarRepository mainBarRepository;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MainBarController(IUniteOfWork uniteOfWork, IMainBarRepository mainBarRepository, IHttpContextAccessor httpContextAccessor)
            : base(mainBarRepository, uniteOfWork, httpContextAccessor)
        {

            _uniteOfWork = uniteOfWork;
            this.mainBarRepository = mainBarRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    } 
}

using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController<INewsRepository, News>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public NewsController(INewsRepository newsRepository, IUniteOfWork uniteOfWork)
            : base(newsRepository, uniteOfWork)
        {
            _newsRepository = newsRepository;
            _uniteOfWork = uniteOfWork;
        }
    }
}

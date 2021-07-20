using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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

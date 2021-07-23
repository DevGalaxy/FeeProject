using Core.Entites;
using Core.IRepository;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FEEWebApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NewsController : BaseController<INewsRepository, News>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly FEEDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewsController(INewsRepository newsRepository, IUniteOfWork uniteOfWork, FEEDbContext db, IHttpContextAccessor httpContextAccessor)
            : base(newsRepository, uniteOfWork,httpContextAccessor)
        {
            _newsRepository = newsRepository;
            _uniteOfWork = uniteOfWork;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override dynamic Get(int id)
        {
            return _db.News.Where(x => x.Id == id).Include(x => x.NewsSubImages).FirstOrDefault();
        }

        
    }
}

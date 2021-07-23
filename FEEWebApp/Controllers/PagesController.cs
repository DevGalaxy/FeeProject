using Core.Entites;
using Core.IRepository;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : BaseController<IPageRepository, Page>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly FEEDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PagesController(IUniteOfWork uniteOfWork, IPageRepository pageRepository, FEEDbContext db, IHttpContextAccessor httpContextAccessor)
            : base(pageRepository, uniteOfWork,httpContextAccessor)
        {

            _uniteOfWork = uniteOfWork;

            _pageRepository = pageRepository;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

    }
}

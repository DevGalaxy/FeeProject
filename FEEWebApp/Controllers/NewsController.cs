using Core.Entites;
using Core.IRepository;
using FEEWebApp.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            : base(newsRepository, uniteOfWork, httpContextAccessor)
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

        [ApiExplorerSettings(IgnoreApi = true)]
        public override dynamic Post(News entity)
        {
            return base.Post(entity);
        }
        [HttpPost("AddNews")]
        public dynamic AddNews(NewsDto entity)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
                var news = new News
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    ImagePath = entity.ImagePath,
                    CreatedAt = DateTime.Now,
                    CreatedById = userId
                };
                _db.News.Add(news);
                _db.SaveChanges();
                foreach (var item in entity.NewsSubImages)
                {
                    _db.NewsSubImages.Add(new NewsSubImages()
                    {
                        ImagePath = item,
                        NewsId = news.Id
                    });
                    _db.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

using Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repo, Entity> :
        Controller where Repo : IRepository<Entity> where Entity : class
    {
        private readonly Repo _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(Repo repo, IUniteOfWork uniteOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _uniteOfWork = uniteOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual dynamic GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public virtual dynamic Get(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public virtual dynamic Post(Entity entity)
        {
            try
            {
                try
                {
                    var userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
                    entity.GetType().GetProperty("CreatedById").SetValue(entity, userId);
                }
                catch
                {

                }
               _repo.Add(entity);
                _uniteOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        public virtual dynamic Put(Entity entity)
        {
            try
            {
                _repo.Update(entity);
                _uniteOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                _repo.Remove(id);
                _uniteOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var currentAction = context.RouteData.Values["action"].ToString();
                var currentController = context.RouteData.Values["controller"].ToString();
                var claims = HttpContext.User.Claims.ToList();
                if (!currentAction.Contains("Get"))
                {
                    if (!HttpContext.User.Claims.Any(x => x.Type == "Permission" && x.Value == $"Permissions.{currentController}.{currentAction}"))
                    {
                        context.HttpContext.Response.StatusCode = 401;
                        context.Result = Unauthorized();
                    }
                }
            }
        }
    }
}

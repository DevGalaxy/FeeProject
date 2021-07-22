using Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repo, Entity> :
        ControllerBase where Repo : IRepository<Entity> where Entity : class
    {
        private readonly Repo _repo;
        private readonly IUniteOfWork _uniteOfWork;
        public BaseController(Repo repo, IUniteOfWork uniteOfWork)
        {
            _repo = repo;
            _uniteOfWork = uniteOfWork;
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
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataAccess.Repository.IRepository;
namespace FEEWebApp.Controllers
{
    public class BaseController<Repo, Entity> :
        ControllerBase where Repo : IRopository<Entity> where Entity : class
    {
        private readonly Repo _repo;
        private readonly IUniteOfWork _uniteOfWork;
        public BaseController(Repo repo, IUniteOfWork uniteOfWork)
        {
            _repo = repo;
            _uniteOfWork = uniteOfWork;
        }

        [HttpGet]
        public dynamic GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public dynamic Post(Entity entity)
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
        public dynamic Put(Entity entity)
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

using Core.Entites;
using Core.IRepository;
using FEEWebApp.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectDepedanceController : ControllerBase
    {
        private readonly FEEDbContext _db;
        public SubjectDepedanceController(FEEDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public dynamic Post(SubjectDepndenceDto obj)
        {
            try
            {
                foreach (var item in obj.DepndencesIds)
                {
                    _db.SubjectDepedances.Add(new SubjectDepedance()
                    {
                        SubjectID = obj.SubjectId,
                        DependID = item
                    });
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            
        }
        [HttpGet]
        public dynamic Get(int subjectId)
        {
           return _db
            .SubjectDepedances
            .Where(x => x.SubjectID == subjectId)
            .ToList();
        }
    }
}
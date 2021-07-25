using Core.Entites;
using Core.IRepository;
using FEEWebApp.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FEEWebApp.Controllers
{

    public class SubjectController : BaseController<ISubjectRepository, Subject>
    {
        private readonly ISubjectRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly FEEDbContext _db;
        public SubjectController(IUniteOfWork uniteOfWork, ISubjectRepository repo, IHttpContextAccessor httpContextAccessor, FEEDbContext db)
            : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        

        [HttpGet("GetAllowdSubjects")]
        public dynamic GetAllowdSubjects(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                userId = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault();
            }
            var studentSubjects = _db
                                .StudentSubjects
                                .Where(x => x.UserId == userId && x.Degree != null)
                                .ToList();
            var allowedSubjects = new List<Subject>();
            foreach (var item in studentSubjects)
            {
                var res = _db
                 .SubjectDepedances
                 .Include(x => x.subject)
                 .Where(x => x.SubjectID == item.SubjectId)
                 .ToList();

                res.ForEach(x =>
                {
                    if (x.subject != null)
                    {
                        if (x.subject.Enabled)
                            allowedSubjects.Add(x.subject);
                    }
                });
            }
            return allowedSubjects;
        }

        [HttpPost("DisableSubjects")]
        [AllowAnonymous]
        public dynamic DisableSubjects(DisableSubjectsDto data)
        {
            try
            {
                foreach (var item in data.Ids)
                {
                    var obj = _repo.Get(item);
                    obj.Enabled = false;
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("EnableSubjects")]
        public dynamic EnableSubjects(DisableSubjectsDto data)
        {
            try
            {
                foreach (var item in data.Ids)
                {
                    var obj = _repo.Get(item);
                    obj.Enabled = true;
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    
    
    
    }
}
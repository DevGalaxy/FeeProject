using Core.Entites;
using Core.IRepository;
using FEEWebApp.Dtos;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    public class DepartmentsController : BaseController<IDepartmentsRepository, Department>
    {
        private readonly IDepartmentsRepository _repo;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly FEEDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DepartmentsController(IUniteOfWork uniteOfWork, IDepartmentsRepository repo, IHttpContextAccessor httpContextAccessor, FEEDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
          : base(repo, uniteOfWork, httpContextAccessor)
        {
            _uniteOfWork = uniteOfWork;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet("{id}")]
        public override dynamic Get(int id)
        {
            var data = _db.Departments.Where(x => x.Id == id)
                .Include(x => x.DepartmentLabs)
                .Include(x => x.DepartmentReports)
                .Include(x => x.Users)
                .ThenInclude(x => x.StaffSubjects)
                .ThenInclude(x => x.Subject)
                .Include(x => x.Users)
                .ThenInclude(x => x.StudentSubjects)
                .ThenInclude(x => x.Subject)
                .FirstOrDefault();

            data.Users = null;
            var departmentUsers = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            data.Users = departmentUsers;
            return data;
        }
        [HttpPost("AssingHead")]
        public dynamic AssignHead(AssignHeadDto obj)
        {
            try
            {
                var dept = _repo.Get(obj.DepartmentId);
                dept.HeadId = obj.UserId;
                _repo.Update(dept);
                return Ok();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("GetHeadInfo/{id}")]
        public dynamic GetHeadInfo(int id)
        {
            try
            {
                var dept = _db.Departments.Find(id);
                var head = _db.Users.Where(x => x.Id == dept.HeadId).FirstOrDefault();
                return head;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
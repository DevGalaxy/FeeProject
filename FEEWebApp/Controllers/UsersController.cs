using Core.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FEEWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure;
using Core.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly FEEDbContext _db;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, FEEDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _db = db;
        }

        [HttpGet("GetUsers")]
        public async Task<List<UserViewModel>> GetUSers()
        {
            var users = await _userManager.Users
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, DepartmentId = user.DepartmentId })
                .ToListAsync();

            users.ForEach(x =>
            {
                x.Roles = _userManager.GetRolesAsync(new ApplicationUser
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                }).Result;
                x.Department = _db.Departments.Where(d => d.Id == x.DepartmentId).FirstOrDefault();
            });
            return users;
        }

        [HttpGet("GetUsersByRoleId/{id}")]
        public List<UserViewModel> GetUsersByRoleId(string id)
        {
            var role = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role != null)
                return FilterData(role.Name);
            else
                return new List<UserViewModel>();
        }

        [HttpGet("GetStaff")]
        public List<UserViewModel> GetStaff()
        {
            return GetUsersByRoleName(Roles.Staff);
        }

        [HttpGet("GetStudents")]
        public List<UserViewModel> GetStudents()
        {
            return GetUsersByRoleName(Roles.Student);
        }
        #region Helpers
        private List<UserViewModel> GetUsersByRoleName(Roles role)
        {
            switch (role)
            {
                case Roles.SuperAdmin:
                    return FilterData(Roles.SuperAdmin.ToString());
                case Roles.Admin:
                    return FilterData(Roles.Admin.ToString());
                case Roles.Staff:
                    return FilterData(Roles.Staff.ToString());
                case Roles.Student:
                    return FilterData(Roles.Student.ToString());
                default:
                    return new List<UserViewModel>();
            }
        }
        private List<UserViewModel> FilterData(string name)
        {
            var users = _userManager.GetUsersInRoleAsync(name).Result
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, DepartmentId = user.DepartmentId })
                .ToList();

            users.ForEach(x =>
            {
                x.Roles = x.Roles = _userManager.GetRolesAsync(new ApplicationUser
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                }).Result;
                x.Department = _db.Departments.Where(d => d.Id == x.DepartmentId).FirstOrDefault();
            });
            return users;
        }
        #endregion

        [HttpGet("GetSpecifcUser/{id}")]
        public async Task<UserViewModel> GetSpecifcUser(string id)
        {
            var user = await _userManager.Users
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, DepartmentId = user.DepartmentId })
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                user.Roles = _userManager.GetRolesAsync(new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                }).Result;
                user.Department = _db.Departments.Where(d => d.Id == user.DepartmentId).FirstOrDefault();
            }
            return user;
        }

        [HttpGet("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistrationRequestDto user)
        {
            // Check if the incoming request is valid
            if (ModelState.IsValid)
            {
                // check i the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    existingUser.Phone = user.Phone;
                    existingUser.Image = user.Image;
                    existingUser.ArabicName = user.ArabicName;
                    existingUser.EnglishName = user.EnglishName;
                    existingUser.DepartmentId = user.DepartmentId;
                    existingUser.EmailConfirmed = true;
                    existingUser.DataOfBirth = user.DataOfBirth;
                    existingUser.AcademicNumber = user.AcademicNumber;
                }


                var isUpdated = await _userManager.UpdateAsync(existingUser);
                if (isUpdated.Succeeded)
                {
                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                    });

                }

                return new JsonResult(new RegistrationResponse()
                {
                    Success = false,
                    Errors = isUpdated.Errors.Select(x => x.Description).ToList()
                }
                        )
                { StatusCode = 500 };
            }

            return BadRequest(new RegistrationResponse()
            {
                Success = false,
                Errors = new List<string>(){
                                            "Invalid data"
                                        }
            });
        }


        [HttpGet("ManageRoles")]
        public async Task<dynamic> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                SelectedRoles = roles.Select(role => new CheckBoxViewModel
                {
                    DisplayValue = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return viewModel;
        }

        [HttpPost("UpdateRoles")]
        public async Task<dynamic> UpdateRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return BadRequest();

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRolesAsync(user, model.UserRoles);

            //foreach (var role in model.Roles)
            //{
            //    if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
            //        await _userManager.RemoveFromRoleAsync(user, role.RoleName);

            //    if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
            //        await _userManager.AddToRoleAsync(user, role.RoleName);
            //}

            return Ok();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var currentAction = context.RouteData.Values["action"].ToString();
                var currentController = context.RouteData.Values["controller"].ToString();
                if (!HttpContext.User.Claims.Any(x => x.Type == "Permission" && x.Value == $"Permission.{currentController}.{currentAction}"))
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = Unauthorized();
                }
            }
        }
    }
}
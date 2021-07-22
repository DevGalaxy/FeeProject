using Core.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FEEWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet("GetUsers")]
        public async Task<List<UserViewModel>> GetUSers()
        {
            var users = await _userManager.Users

                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email })
                .ToListAsync();

            users.ForEach(x =>
            {
                x.Roles = _userManager.GetRolesAsync(new ApplicationUser
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email
                }).Result;
            });
            return users;
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
        [ValidateAntiForgeryToken]
        public async Task<dynamic> UpdateRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();

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
    }
}
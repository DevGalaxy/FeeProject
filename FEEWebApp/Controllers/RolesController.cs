using Core.Entites;
using Core.Enums;
using FEEWebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FEEDbContext _db;
        public UserManager<ApplicationUser> UserManager => _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, FEEDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        [HttpPost]
        public async Task<dynamic> Post(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Role name is required");

            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                return BadRequest("Role is exists!");
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            return Ok();
        }
        [HttpGet("GetRolePermissions")]
        public async Task<dynamic> GetRolePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return BadRequest();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = _db.Permissions.ToList();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p.DispalyName }).ToList();

            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                    permission.IsSelected = true;
            }

            var viewModel = new PermissionsFormViewModel
            {
                RoleId = roleId,
                RoleName = role.Name,
                SelectedClaims = allPermissions
            };

            return viewModel;
        }

        [HttpPost("ManagePermissions")]
        public async Task<dynamic> ManagePermissions(PermissionsFormViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);

                if (role == null)
                    return BadRequest();

                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var claim in roleClaims)
                    await _roleManager.RemoveClaimAsync(role, claim);


                foreach (var claim in model.UserClaims)
                    await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.Trim()));

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        //[HttpPost("addPermissions")]
        //public async Task<dynamic> addPermissions()
        //{
        //    PermissionsFormViewModel model = new PermissionsFormViewModel();
        //    model.RoleId = _roleManager.FindByNameAsync("SuperAdmin").Result.Id;
        //    model.UserClaims = _db.Permissions.Select(x => x.DispalyName).ToList();
        //    try
        //    {
        //        var role = await _roleManager.FindByIdAsync(model.RoleId);

        //        if (role == null)
        //            return BadRequest();

        //        var roleClaims = await _roleManager.GetClaimsAsync(role);

        //        foreach (var claim in roleClaims)
        //            await _roleManager.RemoveClaimAsync(role, claim);


        //        foreach (var claim in model.UserClaims)
        //            await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.Trim()));

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    
    }
}

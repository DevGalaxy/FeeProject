using Core.Entites;
using FEEWebApp.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManager<ApplicationUser> UserManager => _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<dynamic> Post(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", await _roleManager.Roles.ToListAsync());

            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                return "Role is exists!";
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            return Ok();
        }

        //public async Task<IActionResult> ManagePermissions(string roleId)
        //{
        //    var role = await _roleManager.FindByIdAsync(roleId);

        //    if (role == null)
        //        return NotFound();

        //    var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
        //    var allClaims = Permissions.GenerateAllPermissions();
        //    var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();

        //    foreach (var permission in allPermissions)
        //    {
        //        if (roleClaims.Any(c => c == permission.DisplayValue))
        //            permission.IsSelected = true;
        //    }

        //    var viewModel = new PermissionsFormViewModel
        //    {
        //        RoleId = roleId,
        //        RoleName = role.Name,
        //        RoleCalims = allPermissions
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ManagePermissions(PermissionsFormViewModel model)
        //{
        //    var role = await _roleManager.FindByIdAsync(model.RoleId);

        //    if (role == null)
        //        return NotFound();

        //    var roleClaims = await _roleManager.GetClaimsAsync(role);

        //    foreach (var claim in roleClaims)
        //        await _roleManager.RemoveClaimAsync(role, claim);

        //    var selectedClaims = model.RoleCalims.Where(c => c.IsSelected).ToList();

        //    foreach (var claim in selectedClaims)
        //        await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));

        //    return RedirectToAction(nameof(Index));
        //}
    }
}

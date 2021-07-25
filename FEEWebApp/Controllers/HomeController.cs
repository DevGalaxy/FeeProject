using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FEEWebApp.Models;
using System.Reflection;
using Infrastructure;
using Core.Enums;
using Core.Entites;

namespace FEEWebApp.Controllers
{

    public class ControllerActions
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Attributes { get; set; }
        public string ReturnType { get; set; }
        public string DispalyName { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FEEDbContext _db;

        public HomeController(ILogger<HomeController> logger, FEEDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public List<Permission> GeneratePermissions(string module)
        {
            return new List<Permission>()
            {
                new Permission()
                {
                    DispalyName=$"Permissions.{module}.Get",Action="Get",Controller=module
                },
                    new Permission()
                {
                    DispalyName=$"Permissions.{module}.Post",Action="Post",Controller=module
                },   new Permission()
                {
                    DispalyName=$"Permissions.{module}.Put",Action="Put",Controller=module
                },   new Permission()
                {
                    DispalyName=$"Permissions.{module}.Delete",Action="Delete",Controller=module
                }
            };
        }
        public void GenerateAllPermissions()
        {
            var allPermissions = new List<Permission>();
            var modules = Enum.GetValues(typeof(Modules));
            foreach (var item in modules)
            {
                _db.Permissions.AddRange(GeneratePermissions(item.ToString()));
                _db.SaveChanges();
            }

        }
        public IActionResult Index()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
                    .Where(type => type.BaseType == typeof(Controller) || type.BaseType == typeof(ControllerBase))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                    })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            var list = new List<ControllerActions>();
            foreach (var item in controlleractionlist)
            {
                if (item.Action.ToLower() == "get" || item.Action.ToLower() == "getall" || item.Action.ToLower() == "onactionexecuted" || item.Controller.Contains("Base") || item.Controller == "AuthManagementController")
                    continue;
                var customControllerName = item.Controller.Split("Controller")[0];

                _db.Permissions.Add(new Core.Entites.Permission
                {
                    Controller = customControllerName,
                    Action = item.Action,
                    DispalyName = $"Permissions.{customControllerName}.{item.Action}"
                });
                _db.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

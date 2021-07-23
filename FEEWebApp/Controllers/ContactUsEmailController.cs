using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsEmailController : ControllerBase
    {
        private readonly FEEDbContext _db;
        public ContactUsEmailController(FEEDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public dynamic Get()
        {
            return _db.ContactUsEmail.FirstOrDefault();
        }

        [HttpPost("UpdateContactEmail")]
        public dynamic UpdateContactEmail(string email)
        {
            var existingEmail = _db.ContactUsEmail.FirstOrDefault();
            if(existingEmail==null)
            {
                _db.ContactUsEmail.Add(new Core.Entites.ContactUsEmail()
                {
                    Email = email
                });
            }
            else
            {
                existingEmail.Email = email;
            }
            _db.SaveChanges();
            return Ok(); 
        }
    }
}

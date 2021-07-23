using Core.Entites;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly FEEDbContext _db;
        public ContactUsController(FEEDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public dynamic Post(ContactUs model)
        {
            _db.Add(model);
            _db.SaveChanges();
            MailMessage mail = new MailMessage();
            var to = _db.ContactUsEmail.FirstOrDefault();
            string toEmail = "ahmeds.badawy@htomail.com";
            if (to != null)
                toEmail = to.Email;
            mail.To.Add(toEmail);
            mail.From = new MailAddress("feecontactushandeler@gmail.com");
            mail.Subject = model.Subject;
            mail.Body = $"User Email : {model.Email} Message : {model.Description}";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("feecontactushandeler@gmail.com", "Aa123456789!");
            smtp.Send(mail);
            return Ok();
        }

    }
}

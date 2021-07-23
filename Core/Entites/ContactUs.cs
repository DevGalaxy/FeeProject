using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{
    public class ContactUs
    {
        public ContactUs()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

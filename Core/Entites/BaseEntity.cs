using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public virtual ApplicationUser CreatedUser { get; set; }

        public string CreatedById { get; set; }
    }
}

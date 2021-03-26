using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites
{
    public class NewsSubImages
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey(nameof(NewsId))]
        public virtual News News { get; set; }
    }
}

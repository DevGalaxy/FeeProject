using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class News : BaseEntity
    {
        public News()
        {
            NewsSubImages = new HashSet<NewsSubImages>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<NewsSubImages> NewsSubImages { get; set; }

        
    }
}

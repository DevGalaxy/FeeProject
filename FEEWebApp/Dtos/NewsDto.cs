using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Dtos
{
    public class NewsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual List<string> NewsSubImages { get; set; }
    }
}

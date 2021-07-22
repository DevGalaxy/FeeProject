using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites
{
    public class Page : BaseEntity
    {
        public Page()
        {
            QuickLinks = new List<QuickLinks>();
        }
        public virtual List<QuickLinks> QuickLinks{get;set;}
        public int MainBarId { get; set; }
        [ForeignKey(nameof(MainBarId))]
        public MainBar MainBar { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Descriptions { get; set; }
    }
}

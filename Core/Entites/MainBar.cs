using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class MainBar : BaseEntity
    {
        public MainBar()
        {
            MainBars = new List<MainBar>();
        }
        public string Title { get; set; }
        [ForeignKey(nameof(MainBars))]
        public virtual ICollection<MainBar> MainBars { get; set; }
    }
}

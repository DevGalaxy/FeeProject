using System.Collections.Generic;

namespace Core.Entites
{
    public class MainBar : BaseEntity
    {
        public MainBar()
        {
            MainBars = new List<MainBar>();
        }
        public string Title { get; set; }

        public virtual ICollection<MainBar> MainBars { get; set; }
    }
}

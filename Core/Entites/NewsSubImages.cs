using System.ComponentModel.DataAnnotations.Schema;

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

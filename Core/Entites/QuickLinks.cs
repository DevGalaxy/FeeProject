namespace Core.Entites
{
    public class QuickLinks:BaseEntity
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
namespace Core.Entites
{
    public class Position : BaseEntity
    {

        public string Name { get; set; }
        public bool Empty { get; set; }
        public Staff staff { get; set; }
    }
}

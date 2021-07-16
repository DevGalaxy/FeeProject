namespace Core.Entites
{
    public class DepartmentReport : BaseEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
    }
}

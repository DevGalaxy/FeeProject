namespace Core.Entites
{
    public class DepartmentLab : BaseEntity
    {
        public string Name { get; set; }
        public int RoomNum { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
    }
}

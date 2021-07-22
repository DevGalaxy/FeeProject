namespace Core.Entites
{
    public class SubjectDepedance:BaseEntity
    {
        public int SubjectID { get; set; }
        public int DependID { get; set; }

        public virtual Subject subject { get; set; }
        public virtual Subject DependOn { get; set; }
    }
}

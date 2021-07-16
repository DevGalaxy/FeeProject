using Core.Entites;

namespace Core.IRepository
{
    public interface IStudentSubjectRepository : IRepository<StudentSubject>
    {
        public void closeRegistration();

    }
}

using Core.Entites;
using System.Collections.Generic;

namespace Core.IRepository
{
    public interface IStudentSubjectRepository : IRepository<StudentSubject>
    {
        IEnumerable<Subject> GetEnabeledSubjects(int studentID);
    }
}

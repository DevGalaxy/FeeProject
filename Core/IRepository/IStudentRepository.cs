using Core.Entites;
using System.Collections.Generic;

namespace Core.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        ICollection<Subject> degrees(int id);
        ICollection<Subject> sutudingsubjects(int id);
        ICollection<Subject> enabledsubjects(int id);
    }
}

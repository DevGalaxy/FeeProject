using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class StudentRepository : Repository<Student> , IStudentRepository
    {
        private readonly FEEDbContext _db;
        public StudentRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class SubjectRepository : Repository<Subject> , ISubjectRepository
    {
        private readonly FEEDbContext _db;
        public SubjectRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

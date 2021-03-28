using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly FEEDbContext _db;
        public UniteOfWork(FEEDbContext db)
        {
            _db = db;
            // poupulate the Interfaces

        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}

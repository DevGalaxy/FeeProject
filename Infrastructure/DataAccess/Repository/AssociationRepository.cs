using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class AssociationRepository : Repository<Association> , IAssociationRepository
    {
        private readonly FEEDbContext _db;
        public AssociationRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser> , IApplicationUserRepository
    {
        private readonly FEEDbContext _db;
        public ApplicationUserRepository(FEEDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

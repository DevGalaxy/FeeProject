using Core.IRepository;

namespace Infrastructure.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly FEEDbContext _db;


        public UniteOfWork(FEEDbContext db)
        {
            _db = db;

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

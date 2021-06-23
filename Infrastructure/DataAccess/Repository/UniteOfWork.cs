using Infrastructure.DataAccess.Repository.IRepository;

namespace Infrastructure.DataAccess.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly FEEDbContext _db;


        public UniteOfWork(FEEDbContext db)
        {
            _db = db;
            // poupulate the Repository Interfaces  with the Repository classes
            applicationUser = new ApplicationUserRepository(_db);
            association = new AssociationRepository(_db);
            events = new EventsRepository(_db);
            mainBar = new MainBarRepository(_db);
            news = new NewsRepository(_db);
            newsSubImages = new NewsSubImagesRepository(_db);
            staff = new StaffRepository(_db);
            staffSubjects = new StaffSubjectsRepository(_db);
            student = new StudentRepository(_db);
            subject = new SubjectRepository(_db);

        }
        // the Repository Interfaces of the DB models
        public IApplicationUserRepository applicationUser { get; private set; }
        public IAssociationRepository association { get; private set; }
        public IEventsRepository events { get; private set; }
        public IMainBarRepository mainBar { get; private set; }
        public INewsRepository news { get; private set; }
        public INewsSubImagesRepository newsSubImages { get; private set; }
        public IStaffRepository staff { get; private set; }
        public IStaffSubjectsRepository staffSubjects { get; private set; }
        public IStudentRepository student { get; private set; }
        public ISubjectRepository subject { get; private set; }

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

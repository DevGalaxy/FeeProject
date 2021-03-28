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
            // poupulate the Repository Interfaces  with the Repository classes
            applicationUser = new ApplicationUserRepository(_db);
            associationRepository = new AssociationRepository(_db);
            eventsRepository = new EventsRepository(_db);
            mainBarRepository = new MainBarRepository(_db);
            newsRepository = new NewsRepository(_db);
            newsSubImagesRepository = new NewsSubImagesRepository(_db);
            staffRepository = new StaffRepository(_db);
            staffSubjectsRepository = new StaffSubjectsRepository(_db);
            studentRepository = new StudentRepository(_db);
            subjectRepository = new SubjectRepository(_db);

        }
        // the Repository Interfaces of the DB models
        public IApplicationUserRepository applicationUser { get; private set; }
        public IAssociationRepository associationRepository { get; private set; }
        public IEventsRepository eventsRepository { get; private set; }
        public IMainBarRepository mainBarRepository { get; private set; }
        public INewsRepository newsRepository { get; private set; }
        public INewsSubImagesRepository newsSubImagesRepository { get; private set; }
        public IStaffRepository staffRepository { get; private set; }
        public IStaffSubjectsRepository staffSubjectsRepository { get; private set; }
        public IStudentRepository studentRepository { get; private set; }
        public ISubjectRepository subjectRepository { get; private set; }

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

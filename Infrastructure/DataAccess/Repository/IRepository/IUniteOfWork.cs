using System;

namespace Infrastructure.DataAccess.Repository.IRepository
{
    public interface IUniteOfWork : IDisposable
    {
        IApplicationUserRepository applicationUser { get; }
        IAssociationRepository association { get; }
        IEventsRepository events { get; }
        IMainBarRepository mainBar { get; }
        INewsRepository news { get; }
        INewsSubImagesRepository newsSubImages { get; }
        IStaffRepository staff { get; }
        IStaffSubjectsRepository staffSubjects { get; }
        IStudentRepository student { get; }
        ISubjectRepository subject { get; }

        void Save();
    }
}

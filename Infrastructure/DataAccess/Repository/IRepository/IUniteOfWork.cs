using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository.IRepository
{
    public interface IUniteOfWork : IDisposable
    {
        IApplicationUserRepository applicationUser { get;  }
        IAssociationRepository associationRepository { get; }
        IEventsRepository eventsRepository { get; }
        IMainBarRepository mainBarRepository { get; }
        INewsRepository newsRepository { get; }
        INewsSubImagesRepository newsSubImagesRepository { get; }
        IStaffRepository staffRepository { get; }
        IStaffSubjectsRepository staffSubjectsRepository { get; }
        IStudentRepository studentRepository { get; }
        ISubjectRepository subjectRepository { get; }

        void Save();
    }
}

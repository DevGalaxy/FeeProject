using System;

namespace Infrastructure.DataAccess.Repository.IRepository
{
    public interface IUniteOfWork : IDisposable
    {

        void Save();
    }
}

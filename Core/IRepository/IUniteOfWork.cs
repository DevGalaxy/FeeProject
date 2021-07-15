using System;

namespace Core.IRepository
{
    public interface IUniteOfWork : IDisposable
    {

        void Save();
    }
}

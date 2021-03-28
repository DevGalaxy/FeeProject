using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository.IRepository
{
    public interface IUniteOfWork : IDisposable
    {
        void Save();
    }
}

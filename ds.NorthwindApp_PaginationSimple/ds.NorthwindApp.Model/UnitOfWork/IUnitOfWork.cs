using System;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Model.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}

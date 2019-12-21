using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Model.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        NorthwindContext DbContext();
        Task Commit();
    }
}

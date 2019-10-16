using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ds.NorthwindApp.Model.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}

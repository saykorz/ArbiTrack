using ArbiTrack.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Data.Interfaces
{
    public interface IUowData: IDisposable
    {
        ApplicationDbContext Context { get; }

        IRepository<ImpossibleFutureAppModel> ImpossibleFutureApps { get; }

        IRepository<LogModel> Logs { get; }

        int SaveChanges();
    }
}

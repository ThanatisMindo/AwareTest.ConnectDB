using System;
using AwareTest.DataAccess.IRepositories;
using SPWCircularofLux.Data.IRepositories;

namespace SPWCircularofLux.Data
{
	public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        ITerritoriesRepository Territories { get; }
        Task<int> CommitAsync();
    }
}


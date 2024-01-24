using System;
using AwareTest.DataAccess.IRepositories;
using AwareTest.DataAccess.Repositories;
using SPWCircularofLux.Data.IRepositories;
using SPWCircularofLux.Data.Repositories;

namespace SPWCircularofLux.Data
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly AwareServiceDbContext _context;
        private IEmployeeRepository _employeeRepository;
        private ITerritoriesRepository _territoriesRepository;

        public UnitOfWork(AwareServiceDbContext context)
		{
            _context = context;
        }
        public IEmployeeRepository Employee => _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);
        public ITerritoriesRepository Territories => _territoriesRepository = _territoriesRepository ?? new TerritoriesRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


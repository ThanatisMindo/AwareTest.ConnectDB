using SPWCircularofLux.Data.IRepositories;
using SPWCircularofLux.Data.Repositories;
using SPWCircularofLux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AwareTest.ModelNew.Model;
using AwareTest.DataAccess.IRepositories;

namespace AwareTest.DataAccess.Repositories
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private AwareServiceDbContext _dbContext
        {
            get { return Context as AwareServiceDbContext; }
        }
        public EmployeeRepository(AwareServiceDbContext context) : base(context)
        { }

        public async Task<EmployeeModel?> GetWithIncludeAllByIdAsync(int id)
        {
            return await _dbContext.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
        }

        //public async Task<EmployeeModel?> GetWithIncludeAllByxxxxxAsync(string supplierCode)
        //{
        //    return await _dbContext.Employee
        //        .FirstOrDefaultAsync(m => m.SupplierCode == supplierCode);
        //}
    }
}

using AwareTest.ModelNew.Model;
using SPWCircularofLux.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.DataAccess.IRepositories
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        Task<EmployeeModel?> GetWithIncludeAllByIdAsync(int id);
        //Task<SPWSellerInfo?> GetWithIncludeAllBySupplierCodeAsync(string supplierCode);
    }
}

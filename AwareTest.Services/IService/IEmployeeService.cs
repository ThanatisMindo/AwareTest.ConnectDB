using AwareTest.Model.Model.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Services.IService
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetAllEmployee();
    }
}

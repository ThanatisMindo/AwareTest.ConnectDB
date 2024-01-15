using AwareTest.Data.IRepository;
using AwareTest.Model.Model;
using AwareTest.Model.Model.SqlModel;
using AwareTest.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return _employeeRepository.Select();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

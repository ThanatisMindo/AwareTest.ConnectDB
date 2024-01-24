using AwareTest.DataAccess.IRepositories;
using AwareTest.ModelNew.Model;
using AwareTest.Services.IService;
using SPWCircularofLux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        //private IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        //public List<EmployeeModel> GetAllEmployee(int id)
        //{
        //    try
        //    {
        //        return _employeeRepository.GetWithIncludeAllByIdAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<EmployeeModel?> GetEmployeeById(int id)
        {
            try
            {
                return await _unitOfWork.Employee.GetWithIncludeAllByIdAsync(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("error GetProductById : " + ex.Message);
                throw new Exception(ex.Message);
            }

        }
    }
}

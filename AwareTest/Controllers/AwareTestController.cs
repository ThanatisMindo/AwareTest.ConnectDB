using AwareTest.Model.Model;
using AwareTest.Model.Model.SqlModel;
using AwareTest.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AwareTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AwareTestController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public AwareTestController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetFromDB/GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result = new List<EmployeeModel>();
                result = _employeeService.GetAllEmployee();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

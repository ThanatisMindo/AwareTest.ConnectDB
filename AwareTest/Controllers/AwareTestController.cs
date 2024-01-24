using AwareTest.ModelNew.Model;
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

        [HttpGet("GetFromDB/GetEmployeeByID")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            try
            {
                var result = await _employeeService.GetEmployeeById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

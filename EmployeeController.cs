using Microsoft.AspNetCore.Mvc;

namespace Importcsvapi
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ICSVService _csvService;


        public EmployeeController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("write-employee-csv")]
        public async Task<IActionResult> WriteEmployeeCSV([FromBody] List<Employee> employees)
        {
            _csvService.WriteCSV<Employee>(employees);

            return Ok();
        }

        [HttpPost("read-employees-csv")]
        public async Task<IActionResult> GetEmployeeCSV([FromForm] IFormFileCollection file)
        {
            var employees = _csvService.ReadCSV<Employee>(file[0].OpenReadStream());

            return Ok(employees);
        }
    }
}

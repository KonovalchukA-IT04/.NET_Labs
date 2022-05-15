using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Net;
namespace PL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IEmployee_srv _employee;
        private readonly ITeam_srv _team;


        public EmployeeController(ILogger<TeamController> logger, IEmployee_srv employee, ITeam_srv team)
        {
            _logger = logger;
            _employee = employee;
            _team = team;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee_dto employee_dto)
        {
            var employee = await _employee.Get(employee_dto.Id);
            if (employee != null)
            {
                var e = new Error($"Employee with id {employee_dto.Id} already exists.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }


            var team = await _team.Get(employee_dto.TeamId);
            if (team == null)
            {
                var e = new Error($"Team with id {employee_dto.Id} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            employee = await _employee.Create(employee_dto);


            return Ok(employee);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var employee = await _employee.Get(id);
            if (employee == null)
            {
                var e = new Error($"Employee with id {id} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(employee);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employee.GetAll();
            if (!employees.Any())
            {
                var e = new Error("No Employees were found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetСomposition([FromRoute] int id)
        {
            var team = await _team.Get(id);
            if (team == null)
            {
                var e = new Error($"Team with id {id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var employees = await _employee.GetAll();
            var fullness = employees.Where(x => x.TeamId == id).ToList();
            if (!fullness.Any())
            {
                var e = new Error("This team has no employees.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(fullness);
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee_dto employee_dto)
        {
            var employee = await _employee.Get(employee_dto.Id);
            if (employee == null)
            {
                var e = new Error("Employee with such Id doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var team = await _team.Get(employee_dto.TeamId);
            if (team == null)
            {
                var e = new Error($"Team with id {employee_dto.TeamId} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _employee.Update(employee_dto))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok(employee_dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var employee = await _employee.Get(id);
            if (employee == null)
            {
                var e = new Error($"Employee with id {id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _employee.Delete(id))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok();
        }
    }
}

using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Net;
namespace PL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IEmployee_srv _employee;
        private readonly ITeam_srv _team;


        public TeamController(ILogger<TeamController> logger, IEmployee_srv employee, ITeam_srv team)
        {
            _logger = logger;
            _employee = employee;
            _team = team;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Team_dto team_dto)
        {
            var team = await _team.Get(team_dto.Id);
            if (team != null)
            {
                var e = new Error($"Team with id {team_dto.Id} already exists.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }
            team = await _team.Create(team_dto);


            return Ok(team);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var team = await _team.Get(id);
            if (team == null)
            {
                var e = new Error($"Team with id {id} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(team);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var team = await _team.GetAll();
            if (!team.Any())
            {
                var e = new Error("Teams were not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(team);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Team_dto team_dto)
        {
            var team = await _team.Get(team_dto.Id);
            if (team == null)
            {
                var e = new Error($"Team with id {team_dto.Id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _team.Update(team_dto))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok(team_dto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var team = await _team.Get(id);
            if (team == null)
            {
                var e = new Error($"Team with id {id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var employees = await _employee.GetAll();
            var fullness = employees.Where(x => x.TeamId == id).ToList();
            if (fullness != null)
            {
                var e = new Error("There are employees in this team. Team can not be deleted.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }


            if (!await _team.Delete(id))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok();
        }
    }
}

using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Net;
namespace PL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITheTask_srv _thetask;
        private readonly IEmployee_srv _employee;
        private readonly IAssigment_srv _assigment;


        public AssigmentController(ILogger<TeamController> logger,
            ITheTask_srv thetask, 
            IEmployee_srv employee,
            IAssigment_srv assigment)
        {
            _logger = logger;
            _thetask = thetask;
            _employee = employee;
            _assigment = assigment;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Assigment_dto thetaskemployee_dto)
        {
            var entity = await _assigment.Get(thetaskemployee_dto.Id);
            if (entity != null)
            {
                var e = new Error($"Assignment with id {thetaskemployee_dto.Id} already exists.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }
            entity = await _assigment.Create(thetaskemployee_dto);


            return Ok(entity);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var entity = await _assigment.Get(id);
            if (entity == null)
            {
                var e = new Error($"Assigment with id {id} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var employee = await _employee.Get(entity.EmployeeId);
            var thetask = await _thetask.Get(entity.TheTaskId);


            var view = new AsgView()
            {
                Id = entity.Id,
                EmployeeId = employee.Id,
                TeamId = employee.TeamId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,

                TheTaskId = thetask.Id,
                TimeRequired = thetask.TimeRequired,
                Description = thetask.Description,
                Priority = thetask.Priority,
                StateId = thetask.StateId

            };


            return Ok(view);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assigment = await _assigment.GetAll();
            if (!assigment.Any())
            {
                var e = new Error("Assigment were not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var view = new List<AsgView>();
            foreach (var entity in assigment)
            {
                var employee = await _employee.Get(entity.EmployeeId);
                var thetask = await _thetask.Get(entity.TheTaskId);
                view.Add(new AsgView()
                {
                    Id = entity.Id,


                    EmployeeId = employee.Id,
                    TeamId = employee.TeamId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,


                    TheTaskId = thetask.Id,
                    TimeRequired = thetask.TimeRequired,
                    Description = thetask.Description,
                    Priority = thetask.Priority,
                    StateId = thetask.StateId

                });
            }


            return Ok(view);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Assigment_dto thetaskemployee_dto)
        {
            var entity = await _assigment.Get(thetaskemployee_dto.Id);
            if (entity == null)
            {
                var e = new Error($"Assignment with id {thetaskemployee_dto.Id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _assigment.Update(thetaskemployee_dto))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok(thetaskemployee_dto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entity = await _assigment.Get(id);
            if (entity == null)
            {
                var e = new Error($"Assignment with id {id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _assigment.Delete(id))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok();
        }
    }
}

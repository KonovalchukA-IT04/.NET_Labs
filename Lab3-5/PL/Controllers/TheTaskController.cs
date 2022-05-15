using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Net;
namespace PL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TheTaskController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITheTask_srv _thetask;
        private readonly IState_srv _state;

        public TheTaskController(ILogger<TeamController> logger, ITheTask_srv thetask, IState_srv state)
        {
            _logger = logger;
            _thetask = thetask;
            _state = state;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TheTask_dto thetask_dto)
        {
            var team = await _thetask.Get(thetask_dto.Id);
            if (team != null)
            {
                var e = new Error($"Task with id {thetask_dto.Id} already exists.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }
            team = await _thetask.Create(thetask_dto);


            return Ok(team);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var thetask = await _thetask.Get(id);
            if (thetask == null)
            {
                var e = new Error($"No task with id {id}.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(thetask);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var thetask = await _thetask.GetAll();
            if (!thetask.Any())
            {
                var e = new Error("Task were not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(thetask);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetComposition([FromRoute] int id)
        {
            var state = await _state.Get(id);
            if (state == null)
            {
                var e = new Error("State was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            var thetask = await _thetask.GetAll();
            var composition = thetask.Where(x => x.StateId == id).ToList();
            if (!composition.Any())
            {
                var e = new Error($"Tasks with the State {state} was not found.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(composition);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TheTask_dto thetask_dto)
        {
            var thetask = await _thetask.Get(thetask_dto.Id);
            if (thetask == null)
            {
                var e = new Error($"Task with id {thetask_dto.Id} doesn't exists.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _thetask.Update(thetask_dto))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok(thetask_dto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var thetask = await _thetask.Get(id);
            if (thetask == null)
            {
                var e = new Error($"Task with id {id} doesn't exists.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _thetask.Delete(id))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok();
        }
    }
}

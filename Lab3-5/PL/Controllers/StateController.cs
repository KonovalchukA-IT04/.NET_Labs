using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Net;
namespace PL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IState_srv _state;


        public StateController(ILogger<TeamController> logger, IState_srv state)
        {
            _logger = logger;
            _state = state;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] State_dto state_dto)
        {
            var state = await _state.Get(state_dto.Id);
            if (state != null)
            {
                var e = new Error($"State with id {state_dto.Id} already exists.", HttpStatusCode.BadRequest);
                return BadRequest(e);
            }
            state = await _state.Create(state_dto);


            return Ok(state);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var state = await _state.Get(id);
            if (state == null)
            {
                var e = new Error($"No state with id {id}.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(state);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var state = await _state.GetAll();
            if (!state.Any())
            {
                var e = new Error("States were not found", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            return Ok(state);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] State_dto state_dto)
        {
            var state = await _state.Get(state_dto.Id);
            if (state == null)
            {
                var e = new Error("Team with such Id doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _state.Update(state_dto))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok(state_dto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var state = await _state.Get(id);
            if (state == null)
            {
                var e = new Error($"State with id {id} doesn't exist.", HttpStatusCode.NotFound);
                return NotFound(e);
            }


            if (!await _state.Delete(id))
            {
                var e = new Error("Unexpected error.", HttpStatusCode.Conflict);
                return Conflict(e);
            }


            return Ok();
        }
    }
}

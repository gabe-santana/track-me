using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trackapi.DTO;
using trackapi.Model;
using trackapi.Repositories;
using trackapi.Repositories.Interfaces;

namespace trackapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TrackerController : ControllerBase
    {
        private readonly ITrackerRepository trackerRepository;
        public TrackerController(ITrackerRepository trackerRepository)
            => this.trackerRepository = trackerRepository;

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            IEnumerable<TrackerDTO> tracker = await trackerRepository.GetAll();
            return Ok(tracker);
        }

        [HttpGet()]
        public async Task<ActionResult> GetById([FromQuery] string id)
        {
            TrackerDTO tracker = await trackerRepository.GetById(id);
            return Ok(tracker);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tracker tracker)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try{
                var createdTracker = await trackerRepository.Create(tracker);      
                return Ok(createdTracker);
            }catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TrackerDTO tracker)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try{
                var updatedTracker = await trackerRepository.Update(tracker);      
                return Ok(updatedTracker);
            }catch
            {
                return BadRequest();
            }
        }
    
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] string email)
        {
            var query =  await trackerRepository.Delete(email);
            if(query)
                return Ok();
            return BadRequest();
        }
    }
}
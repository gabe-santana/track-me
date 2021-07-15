using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using trackapi.DTO;
using trackapi.Model;
using trackapi.Repositories.Interfaces;

namespace trackapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
         private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
            => this.userRepository = userRepository;


        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            IEnumerable<UserDTO> user = await userRepository.GetAll();
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult> GetByEmail([FromQuery] string email)
        {
            UserDTO user = await userRepository.GetByEmail(email);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try{
                var createdUser = await userRepository.Create(user);      
                return Ok(createdUser);
            }catch
            {
                return BadRequest("User email already exists");
            }
        }
    
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try{
                var updatedUser = await userRepository.Update(user);      
                return Ok(updatedUser);
            }catch
            {
                return BadRequest("User not exists");
            }
        }
   
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] string email)
        {
            var query =  await userRepository.Delete(email);
            if(query)
                return Ok();
            return BadRequest();
        }
    }
}
using System;
using System.Collections;
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
         private readonly IUserRepository UserRepository;

        public UserController(IUserRepository UserRepository)
            => this.UserRepository = UserRepository;



        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try{
                var createdUser = await UserRepository.Create(user);      
                return Ok(createdUser);
            }catch
            {
                return BadRequest("User email already exists");
            }
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string email)
        {
            UserDTO user = UserRepository.GetByEmail(email);
            return Ok(user);
        }
    }
}
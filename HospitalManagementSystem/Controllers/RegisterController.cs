using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalManagementSystem.Repositories;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class RegisterController : Controller
    {
        private readonly IUsersRepository users;

        public RegisterController(IUsersRepository usersRepository)
        {
            this.users = usersRepository;
        }
        
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            
            var createdUser = users.AddUser(user);

            if (createdUser == null)
                return Forbid();

            return Ok(createdUser);
        }
        
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE");
            return resp;

            //return Ok();
        }
    }
}

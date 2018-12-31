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
    public class LoginController : Controller
    {
        private readonly IUsersRepository users;

        public LoginController(IUsersRepository usersRepository)
        {
            this.users = usersRepository;
        }
        
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var resultUser = users.GetUsers().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (resultUser != null)
                return Ok(resultUser);
            
            return NotFound();
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

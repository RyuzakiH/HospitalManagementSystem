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
    public class PatientsController : Controller
    {
        private readonly IPatientsRepository patientsRepository;

        public PatientsController(IPatientsRepository patientRepository)
        {
            this.patientsRepository = patientRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return this.patientsRepository.GetPatients();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return this.patientsRepository.GetPatient(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Patient Post([FromBody]Patient value)
        {
            return this.patientsRepository.AddPatient(value);
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Patient value)
        {
            this.patientsRepository.UpdatePatient(id, value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.patientsRepository.DeletePatient(id);
        }

        [HttpGet("{id}/admit")]
        public void AdmitToHospital(int id)
        {
            this.patientsRepository.AdmitToHospital(id);
        }

        [HttpGet("{id}/discharge")]
        public void DischargeFromHospital(int id)
        {
            this.patientsRepository.DischargeFromHospital(id);
        }

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var x = Ok();
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE");
            return resp;

            //return Ok();
        }
    }
}

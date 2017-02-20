
using MongoDB.Driver;
using PatientData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    // slide 95.2

    // slide 97 - habilitando CORS apenas para um controller
    [EnableCors("*", "*", "GET")]
    // slide 98.1
    [Authorize]
    public class PatientsController : ApiController
    {

        IMongoCollection<Patient> _patients;
        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> Get()
        {
            return _patients.AsQueryable().ToList(); 
        }


        ////Slide 95.3 Versão WebAPI 1
        //public HttpResponseMessage Get(string id)
        //{
        //    var patient = _patients.Find(p => p.Id == id).SingleOrDefault();
        //    if (patient == null)
        //    {

        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");   
        //    }

        //    return Request.CreateResponse(patient);
        //}

        ////Slide 95.4 (rodar antes de marcar com route attribute)
        //[Route("api/patients/{id}/medications")]
        //public HttpResponseMessage GetMedications(string id)
        //{
        //    var patient = _patients.Find(p => p.Id == id).SingleOrDefault();
        //    if (patient == null)
        //    {

        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
        //    }

        //    return Request.CreateResponse(patient.Medications);
        //}

        //Slide 96 Versão WebAPI 2
        public IHttpActionResult Get(string id)
        {
            var patient = _patients.Find(p => p.Id == id).SingleOrDefault();
            if (patient == null)
            {

                return NotFound();
            }

            return Ok(patient);
        }

        ////Slide 96
        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = _patients.Find(p => p.Id == id).SingleOrDefault();
            if (patient == null)
            {

                return NotFound();
            }

            return Ok(patient.Medications);
        }

    }
}

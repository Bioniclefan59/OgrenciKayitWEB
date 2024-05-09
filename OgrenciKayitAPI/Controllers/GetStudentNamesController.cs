using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OgrenciBilgiKayitWEB.OkulDBContext;

namespace OgrenciKayitAPI.Controllers
{
    [RoutePrefix("ogrenciler")]
    public class GetStudentNamesController : ApiController
    {
        private OkulDBCntxt dbContext; 

        public GetStudentNamesController()
        {
            dbContext = new OkulDBCntxt();
        }

        [HttpGet]
        [Route("GetStudentNames")]
        public IHttpActionResult Get()
        {
            var studentNames = dbContext.Ogrenciler
                .Select(s => s.ad + " " + s.soyad)
                .ToList();

            return Ok(studentNames);
        }

        // GET api/<controller>
        public IEnumerable<string> GetStudentByID()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
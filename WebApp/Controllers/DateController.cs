using DB.Date.DbLayer;
using DB.Date.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class DateController : ApiController
    {
        DateLineContext context = new DateLineContext();
        [HttpPost]        
        public IHttpActionResult Add([FromBody]DateLine _dateLine)
        {
            if (_dateLine.LastDate > _dateLine.FirstDate)
            {
                try
                {
                    context.Dates.AddOrUpdate(_dateLine);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest("LastDate bigger then FirstDate");       
        }
        
        [HttpPost]
        [Route("api/AddReturn")]
        public HttpResponseMessage AddAndReturn([FromBody]DateLine _dateLine)
        {
            IEnumerable <DateLine> datesToReturn = DateRange.CheckIntersect(_dateLine, context.Dates);            
            return Request.CreateResponse(HttpStatusCode.OK, datesToReturn);
        }
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult Test([FromBody]DateLine _dateLine)
        {
            return Ok("OkOK!");

        }

    }
}

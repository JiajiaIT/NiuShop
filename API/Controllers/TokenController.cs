using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        [HttpGet]
        [Route("IsExpires")]
        public IHttpActionResult IsExpires(string token)
        {
            return Ok(new Result<bool>()
            {
                Data = new BLL.B_Tokens().CheckToken(token)
            });
        }


        [HttpGet]
        [Route("GetCustomer/{token}")]
        public IHttpActionResult GetCustomer(string token)
        {
            return Ok(new Result<int>()
            {
                Data = new BLL.B_Tokens().GetCustomerIDByToken(token)
            });
        }
    }
}

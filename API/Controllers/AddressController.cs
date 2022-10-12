using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AddressController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetData()
        {
            var result = new Models.Result<List<Model.Address>>()
            {
                Data = new BLL.B_Address().GetAll()
            };
        
            return Ok(result);

        }

    }
}

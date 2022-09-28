using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using IDAL;
using DAL;
using Factory;
using BLL;
using API.Models;

namespace API.Controllers
{
    /// <summary>
    /// 收货地址
    /// </summary>
    [RoutePrefix("api/Address")]
    public class AddressController : ApiController
    {
        BAddress bAddress = new BAddress();
        /// <summary>
        /// 收货地址列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public IHttpActionResult List()
        {
            try
            {
                var data = bAddress.GetAll();
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = data
                });
            }
            catch (Exception)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "失败"
                });
            }
        }
    }
}

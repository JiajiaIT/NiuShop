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
    /// 用户
    /// </summary>
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public IHttpActionResult List()
        {
            try
            {
                BCustomer bCustomer = new BCustomer();
                var data = bCustomer.GetAll();
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "失败"
                });
            }
        }
        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                BCustomer bCustomer = new BCustomer();
                var data = bCustomer.FindByID(id);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "成功",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "失败," + ex
                });
            }
        }
    }
}

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
                    Message = "失败," + ex.Message
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
                    Message = "失败," + ex.Message
                });
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody]Customer customer)
        {

            try
            {
                BCustomer bCustomer = new BCustomer();
                bCustomer.Add(customer);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "添加成功"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "添加失败，" + ex.Message
                });
            }
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]Customer customer)
        {
            try
            {
                BCustomer bCustomer = new BCustomer();
                bCustomer.Update(id, customer);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "修改成功"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "修改失败，" + ex.Message
                });
            }
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                BCustomer bCustomer = new BCustomer();
                bCustomer.Delete(id);
                return Json(new Result<object>
                {
                    Code = 200,
                    Message = "删除成功"
                });
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "删除失败，" + ex.Message
                });
            }
        }
    }
}

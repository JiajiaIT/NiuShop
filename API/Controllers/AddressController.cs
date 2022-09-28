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
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "失败,"+ex.Message
                });
            }
        }
        /// <summary>
        /// 收货地址详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                var data = bAddress.FindByID(id);
                return Json(new Result<object>
                {
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
        /// 添加收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Address address)
        {
            try
            {
                bAddress.Add(address);
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
                    Message = "添加失败," + ex.Message
                });
            }
        }
        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody]Address address)
        {
            try
            {
                bAddress.Update(id, address);
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
                    Message = "修改失败," + ex.Message
                });
            }
        }
        /// <summary>
        /// 删除收货地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                bAddress.Delete(id);
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
                    Code = 202,
                    Message = "删除失败," + ex.Message
                });
            }
        }
    }
}

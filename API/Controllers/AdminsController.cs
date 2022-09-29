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
    /// 管理员
    /// </summary>
    [RoutePrefix("api/Admins")]
    public class AdminsController : ApiController
    {
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public IHttpActionResult List()
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                var data = bAdmins.GetAll();
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
        /// <summary>
        /// 管理员详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindByID/{id}")]
        public IHttpActionResult FindByID(int id)
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                var data = bAdmins.FindByID(id);
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
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Admins admins)
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                bAdmins.Add(admins);
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
                    Message = "添加失败," + ex
                });
            }
        }
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, Admins admins)
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                bAdmins.Update(id, admins);
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
                    Message = "修改失败," + ex
                });
            }
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                bAdmins.Delete(id);
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
                    Message = "删除失败，" + ex
                });
            }
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody]Admins admins)
        {
            try
            {
                BAdmins bAdmins = new BAdmins();
                var data = bAdmins.Login(admins.AdminName, admins.AdminPWD);
                if (data != null)
                {
                    return Json(new Result<object>
                    {
                        Code = 200,
                        Message = "登录成功",
                        Data = data
                    });
                }
                else
                {
                    return Json(new Result<object>
                    {
                        Code = 404,
                        Message = "登录失败"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new Result<object>
                {
                    Code = 404,
                    Message = "登录失败," + ex
                });
            }
        }
    }
}

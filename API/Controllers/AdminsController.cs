using API.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/admins")]
    public class AdminsController : ApiController
    {
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetData")]

        public IHttpActionResult GetData()
        {
            var result = new Models.Result<List<Model.Admins>>()
            {
                Data = new BLL.B_Admins().GetAll()
            };
            return Ok(result);
        }

        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult CheckUser(Param_Admins admin)
        {
            var data = new BLL.B_Admins().CheckUser(admin.Username, admin.Password);

            var result = new Result<Admins>();
            if (data == null)
            {
                result.Code = 404;
                result.Msg = "用户不能存在";
            }

            result.Data = data;

            return Ok(result);
        }

        /// <summary>
        /// 注册管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reg")]
        public IHttpActionResult CreateAdmins(Param_Admins admin)
        {
            var db = new BLL.B_Admins();

            if (db.GetAll().Count(x => x.AdminName == admin.Username) == 0)
            {
                var data = new Admins
                {
                    AdminName = admin.Username,
                    AdminPWD = admin.Password,
                    CreateTime = DateTime.Now
                };
                db.Add(data);

                return Ok(new Result<Admins>()
                {
                    Data = data
                });
            }
            else
            {
                return Ok(new Result<object>
                {
                    Code = 403,
                    Msg = "当前账户已存在"
                });
            }
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                new BLL.B_Admins().Delete(id);
                return Ok(new Result<object>()
                {
                    Msg = "删除成功"
                });
            }
            catch (Exception ex)
            {
                return Ok(new Result<object>()
                {
                    Code = 500,
                    Msg = "该用户已删除"
                });
            }
        }

        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, Param_Admins admin)
        {
            Admins p = new Admins
            {
                AdminPWD = admin.Password
            };

            try
            {
                new BLL.B_Admins().Update(id, p);
                return Ok(new Result<object>());
            }
            catch (Exception)
            {
                return Ok(new Result<object>()
                {
                    Code = 500,
                    Msg = "操作失败，请联系管理员"
                });
            }
        }

        [HttpGet]
        [Route("Find/{id}")]
        public IHttpActionResult FindById(int id)
        {
            return Ok(new Result<Admins>
            {
                Data = new BLL.B_Admins().FindById(id)
            });
        }
    }
}

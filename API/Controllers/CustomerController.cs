using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    //封装与客户有关的业务
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        /*
         登录（分析业务需求--token）

         */

        //注册
        [HttpPost]
        [Route("Reg")]
        public IHttpActionResult Reg(Param_Customer c)
        {
            var customer = new BLL.B_Customer();
            if (customer.GetAll().Where(x => x.CustomerName == c.Account).Count() > 0)
            {
                return Ok(new Result<string>
                {
                    Code = 500,
                    Msg = "当前用户已存在"
                });
            }
            else
            {
                customer.Add(new Model.Customer
                {
                    CustomerName = c.Account,
                    CustomerPWD = c.Password
                });
                return Ok(new Result());
            }
        }
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(Param_Customer c)
        {
            string token = new BLL.B_Customer().Login(c.Account, c.Password);
            if (token == "0")
            {
                return Ok(new Result
                {
                    Code = 404,
                    Msg = "用户名或密码不正确"
                });
            }
            else
            {
                return Ok(new Result<string>
                {
                    Data = token
                });
            }
        }

        //[Filter.MyAuth]
        [HttpGet]
        [Route("GetAddress/{TokenID}")]
        public IHttpActionResult GetAddress(string TokenID)
        {
            return Ok(new Result<List<Model.Address>>()
            {
                Data = new BLL.B_Address().GetAddress(TokenID)
            });
        }


    }
}

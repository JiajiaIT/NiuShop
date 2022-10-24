using API.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/property")]
    public class ProductPropertyController : ApiController
    {
        /// <summary>
        /// 根据型号id显示属性
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getData/{typeid}")]
        public IHttpActionResult GetData(int typeid)
        {
            return Ok(new Models.Result<List<Model.ProductProperty>>()
            {
                Data = new BLL.B_ProductProperty().GetAll().Where(x => x.TypeID == typeid).ToList()
            });
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            new BLL.B_ProductProperty().Delete(id);
            return Ok(new Models.Result());
        }



        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Model.ProductProperty pp)
        {
            //上传图片逻辑
            //将base64上传到图片服务器，然后就将返回的图片路径保存在服务器中
            string url = Common.tools.ImgServer + "Home/Index";
            var data = new Param_Image()
            {
                base64 = pp.IMG,
                imgType = "pp"
            };
            var result = HttpHelper.HttpPost<Result>(url, "post", data);

            pp.CreateTIme = DateTime.Now;
            pp.Description = pp.Description ?? "暂无描述";
            //重新设置图片
            pp.IMG = result.Msg;
            new BLL.B_ProductProperty().Add(pp);
            return Ok(new Models.Result());
        }
    }
}

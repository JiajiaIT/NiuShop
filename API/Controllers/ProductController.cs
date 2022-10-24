using API.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;

namespace API.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        //获取所有商品
        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult GetData()
        {
            var product = new BLL.B_Product().GetAll();
            var board = new BLL.B_ProductBoard();

            //   增加分类名称字段
            var data = from p in product
                       select new View_Product
                       {
                           ProductID = p.ProductID,
                           ProductName = p.ProductName,
                           Description = p.Description,
                           Postage = p.Postage,
                           IsOnline = p.IsOnline,
                           BoardID = p.BoardID,
                           Cover = p.Cover,
                           CreateTIme = p.CreateTIme,
                           BoardName = board.FindById(p.BoardID.Value).BoardNameCN + "(" + board.FindById(p.BoardID.Value).BoardNameEN + ")"
                       };

            return Ok(new Result<List<View_Product>>
            {
                Data = data.ToList()
            });
        }

        //添加商品
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Product product)
        {
            product.CreateTIme = DateTime.Now;
            //将base64上传到图片服务器，然后就将返回的图片路径保存在服务器中
            string url = "http://localhost:29221/" + "Home/Index";
            var data = new Param_Image()
            {
                base64 = product.Cover,
                imgType = "cover"
            };
            var result = HttpHelper.HttpPost<Result>(url, "post", data);
            //更换一下图片
            product.Cover = result.Msg;
            new BLL.B_Product().Add(product);
            return Ok(new Result<object>());
        }

        //删除商品
        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            new BLL.B_Product().Delete(id);
            return Ok(new Result<object>());
        }

        //更新商品
        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, Product p)
        {
            //判断是否需要更新图片（图片中是否为base64格式）
            //或 http://localhost:29221//cover/a64535ec.jpeg 格式

            string url = Common.tools.ImgServer + "Home/Index";
            var data = new Param_Image()
            {
                base64 = p.Cover,
                imgType = "cover"
            };

            //不是base64
            if (p.Cover.IndexOf(';') == -1)
            {
                //裁剪图片路径
                p.Cover = p.Cover.Substring(Common.tools.ImgServer.Length);
            }
            else
            {
                //重新上传逻辑
                var result = HttpHelper.HttpPost<Result>(url, "post", data);
                //更换一下图片
                p.Cover = result.Msg;
            }
            //更新
            new BLL.B_Product().Update(id, p);
            return Ok(new Result<object>());
        }

        //查询指定商品
        [HttpGet]
        [Route("Find/{id}")]
        public IHttpActionResult Find(int id)
        {
            return Ok(new Result<Product>()
            {
                Data = new BLL.B_Product().FindById(id)
            });
        }

        [HttpGet]
        [Route("ProductsByBoardId/{id}")]
        public IHttpActionResult ProductsByBoardId(int id)
        {
            var product = new BLL.B_Product().GetAll();
            var board = new BLL.B_ProductBoard().GetAll();
            var type = new BLL.B_ProductType().GetAll();
            var property = new BLL.B_ProductProperty().GetAll();

            var result = from p in product
                             //join b in board on p.BoardID equals b.BoardID
                         join t in type on p.ProductID equals t.ProductID
                         join pp in property on t.TypeID equals pp.TypeID
                         where p.BoardID == id && p.IsOnline == true
                         group new { p.CreateTIme, pp.Price } by new { p.CreateTIme, p.ProductID, p.Description, p.ProductName, p.Cover } into g     //分组
                         orderby g.Key.CreateTIme descending    //排序
                         select new View_ProductItem
                         {
                             //group 后面跟着的是分组之后需要使用的数据
                             //g.Key 可以直接获取分组依据，即是by后面跟的所有数据
                             ProductID = g.Key.ProductID,
                             Description = g.Key.Description,
                             ProductName = g.Key.ProductName,
                             Cover = g.Key.Cover,
                             MinPrice = g.Min(x => x.Price.Value),
                             MaxPrice = g.Max(x => x.Price.Value)
                         };

            var data = from b in board
                       where b.BoardID == id
                       select new View_Products
                       {
                           BoardId = b.BoardID,
                           BoardNameCN = b.BoardNameCN,
                           BoardNameEN = b.BoardNameEN,
                           ProductList = result.ToList()
                       };

            return Ok(new Result<View_Products>
            {
                Data = data.FirstOrDefault()
            });
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public IHttpActionResult Detail(int id)
        {
            var product = new BLL.B_Product().GetAll();
            var type = new BLL.B_ProductType().GetAll();
            var property = new BLL.B_ProductProperty().GetAll();

            //查询指定商品信息
            var reuslt = from p in product
                         join t in type
                         on p.ProductID equals t.ProductID
                         where p.ProductID == id
                         select new View_Detail
                         {
                             ProductID = p.ProductID,
                             Description = p.Description,
                             ProductName = p.ProductName,
                             TypeID = t.TypeID,
                             TypeName = t.TypeName
                         };
            var detail = reuslt.FirstOrDefault();
            //查询商品下所包含可以购买的属性有哪些
            if (detail != null)
            {
                var data = from pp in property
                           where pp.TypeID == detail.TypeID
                           select new view_ProductProperty
                           {
                               PropertyID = pp.PropertyID,
                               IMG = pp.IMG,
                               Price = pp.Price.Value,
                               PropertyName = pp.PropertyName,
                               Quantity = pp.Quantity.Value
                           };

                detail.PPList = data.ToList();
                return Ok(new Result<View_Detail>()
                {
                    Data = detail
                });
            }
            else
            {
                //商品下没有可购买的属性，则返回500
                return Ok(new Result<object>()
                {
                    Code = 500,
                    Msg = "请联系管理员，添加购买项"
                });
            }


        }
    }
}

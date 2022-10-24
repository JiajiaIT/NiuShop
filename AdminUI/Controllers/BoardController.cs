using AdminUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView();
        }

        public ActionResult Edit(int id)
        {
            //获取服务器数据
            var data = Common.HttpHelper.HttpGet<Result<Board>>(Common.tools.ServerAPI + "api/Board/Find/" + id, "get").Data;
            return PartialView(data);
        }
    }
}
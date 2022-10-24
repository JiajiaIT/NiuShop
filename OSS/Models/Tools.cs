using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;

//using System.Net.http

namespace OSS
{
    public class Tools
    {
        public static string SaveImg(string base64, string imgType)
        {
            if (base64.IndexOf(',') == -1)
                return base64;

            //获取文件要保存的路径
            DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/" + imgType));
            //如果不存在，就建一个
            if (!dir.Exists)
                dir.Create();

            //切割base64源数据
            string data = base64.Split(',')[1];
            string exname = "." + base64.Split(';')[0].Split('/')[1];

            //将base64代码转换成字节
            byte[] buffer = Convert.FromBase64String(data);
            //将字节转换成流
            MemoryStream ms = new MemoryStream(buffer);
            //将流转换成图
            Image image = Image.FromStream(ms);

            //随机名称
            string name = Guid.NewGuid().ToString().Split('-')[0] + exname;

            //服务器路径(绝对路径)
            string path = HttpContext.Current.Server.MapPath("~/" + imgType + "/" + name);
            //保存图片
            image.Save(path);

            return "/" + imgType + "/" + name;
        }
    }
}
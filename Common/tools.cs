using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class tools
    {
        //客户端用的（数据服务器地址）
        public static string ServerAPI = ConfigurationManager.AppSettings["API"].ToString();
        //服务器用的（图片服务器地址）
        public static string ImgServer = ConfigurationManager.AppSettings["ImgServer"].ToString();
    } 

}

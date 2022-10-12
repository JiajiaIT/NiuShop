using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Common
{
    public class HttpHelper
    {//Get方式请求Web Api  （get和delete可同用）
        public static T HttpGet<T>(string url, string meth)
        {//通过HttpWebRequest类请求WebApi资源
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = meth;//设置请求方式
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;//通过“请求”获得“响应”
            Stream S = response.GetResponseStream();//通过“响应”获得“流”。“流”是用来读取来自服务器的响应
            StreamReader SR = new StreamReader(S);//实例对象
            string data = SR.ReadToEnd();//用读取流读取流中的来自服务器响应的数据
            return JsonConvert.DeserializeObject<T>(data);//反序列化(JSON转化成对象)成对象格式使用
        }


        //Post方式请求Web Api   （post和put可同用）
        public static void HttpPost(string url, string meth, object data)
        { //通过HttpWebRequest类请求WebApi资源
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = meth;  //设置请求方式
            request.Accept = "*/*";  //设置HTTP标头的值
            request.ContentType = "application/json";//设置内容格式
            var json = JsonConvert.SerializeObject(data); //将对象数据转换成JSON格式（反序列化）
            byte[] B = Encoding.UTF8.GetBytes(json);//将JSON格式数据转换成网页可读取的2进制格式
            request.GetRequestStream().Write(B, 0, B.Length);//通过响应获得响应的流，并写入数据
            request.GetResponse();//通过请求获得响应
        }

        public static T HttpPost<T>(string url, string meth, object p)
        { //通过HttpWebRequest类请求WebApi资源
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = meth;  //设置请求方式
            request.Accept = "*/*";  //设置HTTP标头的值
            request.ContentType = "application/json";//设置内容格式
            var json = JsonConvert.SerializeObject(p); //将对象数据转换成JSON格式（反序列化）
            byte[] B = Encoding.UTF8.GetBytes(json);//将JSON格式数据转换成网页可读取的2进制格式
            request.GetRequestStream().Write(B, 0, B.Length);//通过响应获得响应的流，并写入数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;//通过“请求”获得“响应”
            Stream S = response.GetResponseStream();//通过“响应”获得“流”。“流”是用来读取来自服务器的响应
            StreamReader SR = new StreamReader(S);//实例对象
            string data = SR.ReadToEnd();//用读取流读取流中的来自服务器响应的数据
            return JsonConvert.DeserializeObject<T>(data);//反序列化(JSON转化成对象)成对象格式使用
        }
    }
}

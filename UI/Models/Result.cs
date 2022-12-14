using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Result<T>
    {
        public int Code { get; set; } = 200;
        public string Msg { get; set; } = "成功";
        public T Data { get; set; } = default(T);
    }

    public class Result
    {
        public int Code { get; set; } = 200;
        public string Msg { get; set; } = "成功";
        public object Data { get; set; } = null;
    }
}
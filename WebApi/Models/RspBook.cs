using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class RspBook
    {
        public string code { get; set; }
        public string msg { get; set; }
        public Books result { get; set; }
    }
}
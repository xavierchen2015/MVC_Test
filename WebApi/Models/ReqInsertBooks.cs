using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ReqInsertBooks
    {
        public string token { get; set; }
        public IList<Books> data { get; set; }
    }
}
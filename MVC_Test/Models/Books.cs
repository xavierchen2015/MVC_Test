using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Books
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicDate { get; set; }
        public int Score { get; set; }
    }
}
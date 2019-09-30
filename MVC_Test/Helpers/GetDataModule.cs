using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using MVC_Test.Models;

namespace MVC_Test.Helpers
{
    public class GetDataModule
    {
        string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
        public List<Books> getAllBooks()
        {
            using (var cn = new SQLiteConnection(conStr))
            {
                var ListBook = cn.Query<Books>("SELECT * FROM Books").ToList();
                
                return ListBook;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Dapper;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class ProcData
    {
        public RspBook InsertBooks(IList<Books> books)
        {
            RspBook rsp = new RspBook();

            string InsertStr = "INSERT INTO Books VALUES (" +
                "@Id, @Name, @PublicDate, @Score" +
                ")";
            try
            {
                string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                using (var cn = new SQLiteConnection(conStr))
                {
                    foreach (var b in books)
                    {
                        cn.Execute(InsertStr, b);
                    }

                }
                rsp.code = "0";
                rsp.msg = "OK";
            }
            catch (Exception ex)
            {
                rsp.code = "1";
                rsp.msg = $"DB insert error: {ex.Message}";
                return rsp;
            }

            return rsp;
        }
        public RspBook DelBook(string id)
        {
            
            RspBook rsp = new RspBook();

            string InsertStr = "DELETE FROM Books WHERE Id= @Id";
            try
            {
                string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                using (var cn = new SQLiteConnection(conStr))
                {
                    cn.Execute(InsertStr, new { Id = new DbString { Value = id, IsFixedLength = true, Length = 3, IsAnsi = true } });
                }
                rsp.code = "0";
                rsp.msg = "OK";
            }
            catch (Exception ex)
            {
                rsp.code = "1";
                rsp.msg = $"DB insert error: {ex.Message}";
                return rsp;
            }

            return rsp;
        }
    }
}
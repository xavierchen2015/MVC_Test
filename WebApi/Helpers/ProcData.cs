using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Dapper;
using WebApi.Models;
using Newtonsoft.Json;

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

            string SqlStr = "DELETE FROM Books WHERE Id= @Id";
            try
            {
                string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                using (var cn = new SQLiteConnection(conStr))
                {
                    cn.Execute(SqlStr, new { Id = new DbString { Value = id, IsFixedLength = true, Length = 3, IsAnsi = true } });
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
        public RspBook UpdateBook(string id, IList<Books> book)
        {
            
            RspBook rsp = new RspBook();
            if (id != book[0].Id)
            {
                rsp.code = "1";
                rsp.msg = "Id Error";
                return rsp;
            }
            string SqlStr = "UPDATE Books SET " +
                "Name=@Name, PublicDate=@PublicDate, Score=@Score " +
                "WHERE Id= @Id";
            
            var datas =  new { Name = book[0].Name, PublicDate = book[0].PublicDate, Score = book[0].Score, Id = book[0].Id };

            try
            {
                string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                using (var cn = new SQLiteConnection(conStr))
                {
                    cn.Execute(SqlStr, datas);
                }
                rsp.code = "0";
                rsp.msg = "OK";
            }
            catch (Exception ex)
            {
                rsp.code = "1";
                rsp.msg = $"DB error: {ex.Message}";
                return rsp;
            }

            return rsp;
        }
        public RspBook GetBookforId(string id)
        {

            RspBook rsp = new RspBook();

            Books book;

            try
            {
                string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                using (var cn = new SQLiteConnection(conStr))
                {
                     book = cn.Query<Books>("SELECT * FROM Books WHERE Id = @Id", new { Id=id}).FirstOrDefault();
                }
                rsp.code = "0";
                rsp.msg = "OK";
                rsp.result = book;
            }
            catch (Exception ex)
            {
                rsp.code = "1";
                rsp.msg = $"DB error: {ex.Message}";
                return rsp;
            }

            return rsp;
        }
    }
}
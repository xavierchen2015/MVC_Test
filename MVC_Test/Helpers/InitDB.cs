using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using MVC_Test.Models;

namespace MVC_Test.Helpers
{
    public class InitDB
    {
        public static void InitData()
        {
            if (!File.Exists(@"d:\db.sqlite"))
            {
                string InsertStr = "INSERT INTO Books VALUES (" +
                "@Id, @Name, @PublicDate, @Score" +
                ")";

                Books[] TestData = new Books[]
                {
                    new Books() {Id = "1",Name = "被討厭的勇氣：自我啟發之父「阿德勒」的教導",PublicDate = DateTime.Parse("2014/10/30"),Score = 8},
                    new Books() {Id = "2",Name = "OKR：做最重要的事",PublicDate = DateTime.Parse("2019/01/30"),Score = 9},
                    new Books() {Id = "3",Name = "原子習慣：細微改變帶來巨大成就的實證法則",PublicDate = DateTime.Parse("2019/06/01"),Score = 7},
                    new Books() {Id = "4",Name = "蔡康永的情商課：為你自己活一次",PublicDate = DateTime.Parse("2018/11/01"),Score = 8}
                };


                string str = InsertStr;
                try
                {
                    string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["xdb"].ConnectionString;
                    using (var cn = new SQLiteConnection(conStr))
                    {
                        cn.Execute(@"
                        CREATE TABLE Books (
                            Id VARCHAR(16),
                            Name VARCHAR(32),
                            PublicDate DATETIME,
                            Score INTEGER,
                            CONSTRAINT Books_PK PRIMARY KEY (Id)
                        )");

                        cn.Execute(str, TestData);
                    }
                }
                catch
                {

                }

            }
        }
    }
}
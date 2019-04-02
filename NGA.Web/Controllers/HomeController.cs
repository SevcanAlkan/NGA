using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NGA.Core.Enum;
using NGA.Data;
using NGA.Domain;
using NGA.Web.Models;

namespace NGA.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult APILog()
        {
            List<Log> logs = new List<Log>();

            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSetting["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand("select * from Logs", conn);

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    logs.Add(new Log()
                    {
                        ActionName = rdr["ActionName"] == null ? "" : (string)rdr["ActionName"],
                        ControllerName = rdr["ControllerName"] == null ? "" : (string)rdr["ControllerName"],
                        CreateDate = rdr["CreateDate"] == null ? DateTime.MinValue : (DateTime)rdr["CreateDate"],
                        Id = rdr["Id"] == null ? Guid.Empty : (Guid)rdr["Id"],
                        IsDeleted = rdr["IsDeleted"] == null ? false : (Boolean)rdr["IsDeleted"],
                        MethodType = rdr["MethodType"] == null ? HTTPMethodType.Unknown : (HTTPMethodType)rdr["MethodType"],
                        Path = rdr["Path"] == null ? "" : (string)rdr["Path"],
                        RequestBody = rdr["RequestBody"] == null ? "" : (string)rdr["RequestBody"],
                        ResponseTime = rdr["ResponseTime"] == null ? 0 : (int)rdr["ResponseTime"],
                        ReturnTypeName = rdr["ReturnTypeName"] == null ? "" : (string)rdr["ReturnTypeName"]
                    });
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }

            return View(logs);
        }

        public IActionResult APILogDetail(Guid Id)
        {
            if (Id == null || Id == Guid.Empty)
                return RedirectToAction("APILog");

            Log rec = new Log();

            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSetting["ConnectionStrings:DefaultConnection"]);
            SqlCommand cmd = new SqlCommand("select TOP 1 * from Logs where Id = '" + Id.ToString() + "'", conn);

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rec.ActionName = rdr["ActionName"] == null ? "" : (string)rdr["ActionName"];
                    rec.ControllerName = rdr["ControllerName"] == null ? "" : (string)rdr["ControllerName"];
                    rec.CreateDate = rdr["CreateDate"] == null ? DateTime.MinValue : (DateTime)rdr["CreateDate"];
                    rec.Id = rdr["Id"] == null ? Guid.Empty : (Guid)rdr["Id"];
                    rec.IsDeleted = rdr["IsDeleted"] == null ? false : (Boolean)rdr["IsDeleted"];
                    rec.MethodType = rdr["MethodType"] == null ? HTTPMethodType.Unknown : (HTTPMethodType)rdr["MethodType"];
                    rec.Path = rdr["Path"] == null ? "" : (string)rdr["Path"];
                    rec.RequestBody = rdr["RequestBody"] == null ? "" : (string)rdr["RequestBody"];
                    rec.ResponseTime = rdr["ResponseTime"] == null ? 0 : (int)rdr["ResponseTime"];
                    rec.ReturnTypeName = rdr["ReturnTypeName"] == null ? "" : (string)rdr["ReturnTypeName"];
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }

            return View(rec);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

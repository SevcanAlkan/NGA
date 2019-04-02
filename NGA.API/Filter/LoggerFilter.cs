using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NGA.Core;
using NGA.Core.Enum;
using NGA.Core.Parameter;
using NGA.Core.Validation;
using NGA.Data;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGA.API.Filter
{
    public class LoggerFilter : IActionFilter
    {
        private readonly NGADbContext con;

        public LoggerFilter(NGADbContext _con)
        {
            con = _con;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (ParameterValue.SYS01001)
                {
                    //Get Values
                    string actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;
                    string controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;
                    string httpMethodType = filterContext.HttpContext.Request.Method;
                    string path = filterContext.HttpContext.Request.Host + filterContext.HttpContext.Request.Path;
                    var requestBody = filterContext.ActionArguments.ToArray();
                    string returnType = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor).MethodInfo.ReturnType.FullName;

                    //Create entity
                    Log rec = new Log();
                    rec.Id = Guid.NewGuid();
                    filterContext.HttpContext.Response.Headers["RequestID"] = rec.Id.ToString();
                    rec.CreateDate = DateTime.Now;
                    rec.Path = Validation.IsNull(path) ? "-" : path;
                    rec.ActionName = Validation.IsNull(actionName) ? "-" : actionName;
                    rec.ControllerName = Validation.IsNull(controllerName) ? "-" : controllerName;
                    rec.ReturnTypeName = Validation.IsNull(returnType) ? "-" : returnType;

                    rec.MethodType = Validation.IsNull(httpMethodType) ? HTTPMethodType.Unknown :
                        (httpMethodType.ToUpper() == "POST" ? HTTPMethodType.POST :
                        (httpMethodType.ToUpper() == "PUT" ? HTTPMethodType.PUT :
                        (httpMethodType.ToUpper() == "DELETE" ? HTTPMethodType.DELETE :
                        (httpMethodType.ToUpper() == "GET" ? HTTPMethodType.GET : HTTPMethodType.Unknown))));
                    if (requestBody == null || requestBody.Length <= 0)
                        rec.RequestBody = "";
                    else

                        rec.RequestBody = JsonConvert.SerializeObject(requestBody.Select(s => s.Value).FirstOrDefault());

                    con.Set<Log>().Add(rec);
                    con.SaveChangesAsync();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Message:" + Ex.Message + "/n Source: " + Ex.Source + "/n StackTrace: " + Ex.StackTrace);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                if (ParameterValue.SYS01001)
                {
                    Guid id = new Guid(filterContext.HttpContext.Response.Headers["RequestID"].FirstOrDefault());

                    if (id != null && id != Guid.Empty)
                    {
                        Log rec = con.Set<Log>().FirstOrDefault(p => p.Id == id);
                        if (rec != null)
                        {
                            rec.ResponseTime = (DateTime.Now - rec.CreateDate).Milliseconds;

                            con.Entry(rec).State = EntityState.Modified;
                            con.SaveChangesAsync();
                        }
                    }

                    filterContext.HttpContext.Response.Headers.Remove("RequestID");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Message:" + Ex.Message + "/n Source: " + Ex.Source + "/n StackTrace: " + Ex.StackTrace);
            }
        }
    }
}

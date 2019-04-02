using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NGA.Core;
using NGA.Core.Helper;
using NGA.Data;
using NGA.Data.Service;
using NGA.Data.ViewModel;
using NGA.Domain;

namespace NGA.API.Controllers
{
    public class ParameterController : DefaultApiController<ParameterAddVM, ParameterUpdateVM, ParameterVM, IParameterService>
    {
        public ParameterController(IParameterService service)
             : base(service)
        {

        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public JsonResult getlist()
        {
            var result = _service.GetAll();

            if (result == null)
                return new JsonResult(APIResult.CreateVM(false, null, AppStatusCode.WRG01001));

            return new JsonResult(result);
        }
    }
}

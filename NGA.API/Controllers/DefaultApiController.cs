using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGA.Core;
using NGA.Core.Helper;
using NGA.Core.Model;
using NGA.Core.Validation;
using NGA.Data.SubStructure;

namespace NGA.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class DefaultApiController<A, U, G, S> : ControllerBase
             where A : AddVM, IAddVM, new()
             where U : UpdateVM, IUpdateVM, new()
             where G : BaseVM, IBaseVM, new()
             where S : ICRUDService<A, U, G>
    {
        protected S _service;

        public DefaultApiController(S service)
        {
            this._service = service;
        }

        public virtual JsonResult Get()
        {
            var result = _service.GetAll();

            if (result == null)
                return new JsonResult(APIResult.CreateVM(false, null, AppStatusCode.WRG01001));

            return new JsonResult(result);
        }

        public virtual async Task<JsonResult> GetById(Guid id)
        {
            if (Validation.IsNullOrEmpty(id))
                return new JsonResult(APIResult.CreateVM(false, null, AppStatusCode.WRG01002));

            var result = await _service.GetByID(id);

            if (result == null)
                return new JsonResult(APIResult.CreateVM(false, null, AppStatusCode.WRG01001));

            return new JsonResult(APIResult.CreateVMWithRec<G>(result, true, result.Id));
        }

        [HttpPost]
        public virtual async Task<JsonResult> Add(A model)
        {
            if (Validation.IsNull(model))
                APIResult.CreateVM(false, null, AppStatusCode.WRG01001);

            var result = await _service.Add(model);

            if (Validation.ResultIsNotTrue(result))
                return new JsonResult(APIResult.CreateVM(true, result.RecId));

            return new JsonResult(APIResult.CreateVM(true, result.RecId));
        }

        [HttpPut]
        public virtual async Task<JsonResult> Update(Guid id, U model)
        {
            if (Validation.IsNull(model))
                APIResult.CreateVM(false, id, AppStatusCode.WRG01001);

            var result = await _service.Update(id, model);

            if (Validation.ResultIsNotTrue(result))
                return new JsonResult(APIResult.CreateVM(true, result.RecId));

            return new JsonResult(APIResult.CreateVM(true, result.RecId));
        }

        [HttpDelete]
        public virtual async Task<JsonResult> Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
                APIResult.CreateVM(false, null, AppStatusCode.WRG01001);

            var result = await _service.Delete(id);

            if (Validation.ResultIsNotTrue(result))
                return new JsonResult(APIResult.CreateVM(true, result.RecId));

            return new JsonResult(APIResult.CreateVM(true, result.RecId));
        }
    }

    public interface IBaseController<A, U>
        where A : AddVM, IAddVM
        where U : UpdateVM, IUpdateVM
    {
        Task<ActionResult> Add(A model, bool saveAndClose = true);
        Task<ActionResult> Delete(Guid id);
        ActionResult Get(Guid id);
        Task<ActionResult> Update(Guid id, U model, bool saveAndClose = true);
    }
}
using NGA.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGA.Core.Helper
{
    public static class APIResult
    {
        public static APIResultVM CreateVM(bool isSuccessful = false, Guid? recId = null, string statusCode = "")
        {
            var vm = new APIResultVM()
            {
                Result = isSuccessful,
                RecId = recId,
                StatusCode = statusCode,
            };
            return vm;
        }
        
        public static APIResultVM CreateVMWithRec<T>(T rec, bool isSuccessful = false, Guid? recId = null, string statusCode = "")
        {
            var vm = new APIResultVM()
            {
                Result = isSuccessful,
                RecId = recId,
                StatusCode = statusCode,
                Rec = rec,
            };

            return vm;
        }

        public static async Task<APIResultVM> CreateVMWithRecAsync<T>(T rec, bool isSuccessful = false, Guid? recId = null, string statusCode = "")
        {
           

            var vm = new APIResultVM()
            {
                Result = isSuccessful,
                RecId = recId,
                StatusCode = statusCode,
                Rec = rec,
            };

            Task.Delay(1);

            return vm;
        }
    }
}

using NGA.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Core.Helper
{
    public static class API
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
    }
}

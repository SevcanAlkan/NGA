using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Core.Model
{
    public interface IIsResultVM
    {
        bool Result { get; set; }
    }
    
    public class APIResultVM : IIsResultVM
    {
        public Guid? RecId { get; set; }
        [JsonIgnore]
        public object Rec { get; set; }
        public bool Result { get; set; }
        public string StatusCode { get; set; }
    }
}

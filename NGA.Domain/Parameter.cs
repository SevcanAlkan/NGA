using NGA.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NGA.Domain
{
    public class ParameterBase : Table
    {
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(10)]
        public string GroupCode { get; set; }
        public string Value { get; set; }
        [DefaultValue(0)]
        public int OrderIndex { get; set; }
    }

    public class Parameter : ParameterBase
    {
        #region Foregin Keys
        #endregion
    }
}

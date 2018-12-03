using NGA.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Core.Model
{
    public interface IBaseVM
    {
        Guid Id { get; set; }
    }
    public class BaseVM : IBaseVM
    {
        [GuidValidation]
        public Guid Id { get; set; }
    }

    public interface ITableVM : IBaseVM
    {
        DateTime CreateDT { get; set; }
        DateTime? UpdateDT { get; set; }
        Guid CreateBy { get; set; }
        Guid UpdateBy { get; set; }
    }
    public class TableVM : BaseVM, ITableVM
    {
        public DateTime CreateDT { get; set; }
        public DateTime? UpdateDT { get; set; }
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
    }

    public interface IAddVM : IBaseVM
    {
    }
    public class AddVM : BaseVM, IAddVM
    {
    }

    public interface IUpdateVM : IBaseVM
    {
    }
    public class UpdateVM : BaseVM, IUpdateVM
    {
    }
}

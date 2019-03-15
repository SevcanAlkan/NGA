using NGA.Core.Enum;
using NGA.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Data.ViewModel
{
    public class AnimalVM : BaseVM 
    {
        public string NickName { get; set; }
        public AnimalStatus Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public Gender Gender { get; set; }
    }

    public class AnimalAddVM : AddVM
    {
        public string NickName { get; set; }
        public AnimalStatus Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid TypeId { get; set; }
        public Gender Gender { get; set; }
    }

    public class AnimalUpdateVM : UpdateVM
    {
    }
}

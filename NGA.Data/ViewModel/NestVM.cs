﻿using NGA.Core.Enum;
using NGA.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NGA.Data.ViewModel
{
    public class NestVM : BaseVM 
    {
        public string Name { get; set; }
        public NestStatus Status { get; set; }
        public DateTime? LastRepaireDate { get; set; }
        public DateTime? LastCheckDate { get; set; }

        public int XCordinate { get; set; }
        public int YCordinate { get; set; }
    }

    public class NestAddVM : AddVM
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, DefaultValue(NestStatus.NoInfo)]
        public NestStatus Status { get; set; }
        public DateTime? LastRepaireDate { get; set; }
        public DateTime? LastCheckDate { get; set; }

        [Required, Range(int.MinValue, int.MaxValue)]
        public int XCordinate { get; set; }
        [Required, Range(int.MinValue, int.MaxValue)]
        public int YCordinate { get; set; }
    }

    public class NestUpdateVM : UpdateVM
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, DefaultValue(NestStatus.NoInfo)]
        public NestStatus Status { get; set; }
        public DateTime? LastRepaireDate { get; set; }
        public DateTime? LastCheckDate { get; set; }

        [Required, Range(int.MinValue, int.MaxValue)]
        public int XCordinate { get; set; }
        [Required, Range(int.MinValue, int.MaxValue)]
        public int YCordinate { get; set; }
    }
}

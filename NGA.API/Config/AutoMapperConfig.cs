using AutoMapper;
using NGA.Data.ViewModel;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGA.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Animal, AnimalVM>();
            CreateMap<Animal, AnimalAddVM>();
            CreateMap<Animal, AnimalUpdateVM>();


        }
    }
}

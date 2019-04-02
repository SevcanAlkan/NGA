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

            CreateMap<AnimalType, AnimalTypeVM>();
            CreateMap<AnimalType, AnimalTypeAddVM>();
            CreateMap<AnimalType, AnimalTypeUpdateVM>();

            CreateMap<Parameter, ParameterVM>();
            CreateMap<Parameter, ParameterAddVM>();
            CreateMap<Parameter, ParameterUpdateVM>();

            CreateMap<Nest, NestVM>();
            CreateMap<Nest, NestAddVM>();
            CreateMap<Nest, NestUpdateVM>();

            CreateMap<NestAnimal, NestAnimalVM>();
            CreateMap<NestAnimal, NestAnimalAddVM>();
            CreateMap<NestAnimal, NestAnimalUpdateVM>();

            CreateMap<User, UserVM>();
            CreateMap<User, UserAddVM>();
            CreateMap<User, UserUpdateVM>();

        }
    }
}

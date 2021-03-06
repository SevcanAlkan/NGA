﻿using AutoMapper;
using NGA.Data.SubStructure;
using NGA.Data.ViewModel;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Data.Service
{
    public class AnimalTypeService : BaseService<AnimalTypeAddVM, AnimalTypeUpdateVM, AnimalTypeVM, AnimalType>, IAnimalTypeService
    {
        #region Ctor

        public AnimalTypeService(UnitOfWork _uow, IMapper _mapper)
            : base(_uow, _mapper)
        {

        }

        #endregion

        #region Methods                

        #endregion
    }

    public interface IAnimalTypeService : IBaseService<AnimalTypeAddVM, AnimalTypeUpdateVM, AnimalTypeVM, AnimalType>
    {

    }
}

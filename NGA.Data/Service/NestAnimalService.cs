﻿using AutoMapper;
using NGA.Data.SubStructure;
using NGA.Data.ViewModel;
using NGA.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGA.Data.Service
{
    public class NestAnimalService : BaseService<NestAnimalAddVM, NestAnimalUpdateVM, NestAnimalVM, NestAnimal>, INestAnimalService
    {
        #region Ctor

        public NestAnimalService(UnitOfWork _uow, IMapper _mapper)
            : base(_uow, _mapper)
        {

        }

        #endregion

        #region Methods                

        #endregion
    }

    public interface INestAnimalService : IBaseService<NestAnimalAddVM, NestAnimalUpdateVM, NestAnimalVM, NestAnimal>
    {

    }
}

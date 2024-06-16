﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.BL
{
    public class MapperSingleton
    {
        private static IMapper _mapper;
        public static IMapper GetMapperInstance()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DtoMapper>(); // DtoMapper sınıfını ekleyin
                });
                _mapper = config.CreateMapper();
            }

            return _mapper;
        }
    }
}

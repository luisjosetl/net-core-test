using AutoMapper;
using catalog.api.DTOs;
using catalog.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}

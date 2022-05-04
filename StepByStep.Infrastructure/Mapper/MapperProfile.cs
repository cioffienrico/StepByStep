using AutoMapper;
using StepByStep.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, DataAccess.Entities.Customer>().ReverseMap();
        }
    }
}

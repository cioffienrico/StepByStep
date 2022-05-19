using AutoMapper;
using StepByStep.Domain;

namespace StepByStep.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, DataAccess.Entities.Customer>().ReverseMap();
            CreateMap<Address, DataAccess.Entities.Address>().ReverseMap();
        }
    }
}

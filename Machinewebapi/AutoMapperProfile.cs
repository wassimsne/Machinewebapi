using AutoMapper;
using Machinewebapi.DTO;
using SharedLibrary.Models;

namespace Machinewebapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MachineDTO, Machine>().ReverseMap();
            CreateMap<LaverieDTO, Laverie>().ReverseMap();
            CreateMap<MachineDTO1, Machine>().ReverseMap();
        }
    }
}

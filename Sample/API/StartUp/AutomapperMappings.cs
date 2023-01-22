using API.Models;
using AutoMapper;
using Core.Entities;

namespace API.StartUp
{
    public class AutomapperMappings : Profile
    {
        public AutomapperMappings()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}

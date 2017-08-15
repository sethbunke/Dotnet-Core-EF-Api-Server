using AutoMapper;
using Dotnet_Core_EF_Api_Server.Controllers.Resources;
using Dotnet_Core_EF_Api_Server.Models;

namespace Dotnet_Core_EF_Api_Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}
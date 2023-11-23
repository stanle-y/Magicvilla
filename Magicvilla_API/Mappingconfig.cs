using AutoMapper;
using Magicvilla_API.modelos;
using Magicvilla_API.modelos.DTO;

namespace Magicvilla_API
{
    public class Mappingconfig : Profile
    {
        public Mappingconfig()
        {
            CreateMap<Villa,VillaDTO>();
            CreateMap<Villa, Villa>();

            CreateMap<Villa,VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();
            
        }

    }
}

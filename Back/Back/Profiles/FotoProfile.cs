using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {
            
            CreateMap<Foto, FotoDTO>();
            CreateMap<FotoDTO, Foto>();


        }
    }
}

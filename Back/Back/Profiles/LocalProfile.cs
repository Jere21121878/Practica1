using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class LocalProfile : Profile
    {
        public LocalProfile()
        {

            CreateMap<Local, LocalDTO>();
            CreateMap<LocalDTO, Local>();


        }
    }
}

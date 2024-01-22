using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();


        }
    }
}

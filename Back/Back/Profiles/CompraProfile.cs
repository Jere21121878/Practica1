using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class CompraProfile : Profile
    {
        public CompraProfile()
        {

            CreateMap<Compra, CompraDTO>();
            CreateMap<CompraDTO, Compra>();


        }
    }
}

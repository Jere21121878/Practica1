using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class LocalCompraProfile : Profile
    {
        public LocalCompraProfile()
        {

            CreateMap<LocalCompra, LocalCompraDTO>();
            CreateMap<LocalCompraDTO, LocalCompra>();


        }
    }
}

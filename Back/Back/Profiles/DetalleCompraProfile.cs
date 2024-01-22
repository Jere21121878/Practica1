using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class DetalleCompraProfile : Profile
    {
        public DetalleCompraProfile()
        {

            CreateMap<DetalleCompra, DetalleCompraDTO>();
            CreateMap<DetalleCompraDTO, DetalleCompra>();


        }
    }
}

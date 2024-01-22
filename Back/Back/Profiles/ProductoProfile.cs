using AutoMapper;
using Back.DTO;
using Back.Models;

namespace Back.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {

            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();


        }
    }
}

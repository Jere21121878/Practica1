using Back.Models;

namespace Back.Repository
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetListPro();
        Task<Producto> GetPro(int Id);
        Task DeletePro(Producto producto);
        Task<Producto> AddPro(Producto producto);
        Task UpdatePro(Producto producto);

    }
}

using Back.Models;

namespace Back.Repository
{
    public interface IDetalleCompraRepository
    {
        Task<List<DetalleCompra>> GetListDC();
        Task<DetalleCompra> GetDC(int Id);
        Task DeleteDC(DetalleCompra detalleCompra);
        Task<DetalleCompra> AddDC(DetalleCompra detalleCompra);
        Task UpdateDC(DetalleCompra detalleCompra);
    }
}

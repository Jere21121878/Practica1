using Back.Models;

namespace Back.Repository
{
    public interface ILocalCompraRepository
    {
        Task<List<LocalCompra>> GetListLC();
        Task<LocalCompra> GetLC(int Id);
        Task DeleteLC(LocalCompra localCompra);
        Task<LocalCompra> AddLC(LocalCompra localCompra);
        Task UpdateLC(LocalCompra localCompra);
    }
}

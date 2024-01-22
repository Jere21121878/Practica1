using Back.Models;

namespace Back.Repository
{
    public interface ICompraRepository
    {
        Task<List<Compra>> GetListCom();
        Task<Compra> GetCom(int Id);
        Task DeleteCom(Compra compra);
        Task<Compra> AddCom(Compra compra);
        Task UpdateCom(Compra compra);
    }
}

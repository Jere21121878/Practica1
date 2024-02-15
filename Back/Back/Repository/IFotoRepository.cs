using Back.Models;

namespace Back.Repository
{
    public interface IFotoRepository
    {
        Task<List<Foto>> GetListFo();
        Task<Foto> GetFo(int Id);
        Task DeleteFo(Foto foto);
        Task<Foto> AddFo(Foto foto);
        Task UpdateFo(Foto foto);
    }
}

using Back.Models;

namespace Back.Repository
{
    public interface ILocalRepository
    {
        Task<List<Local>> GetListLoc();
        Task<Local> GetLoc(int Id);
        Task DeleteLoc(Local local);
        Task<Local> AddLoc(Local local);
        Task UpdateLoc(Local local);
    }
}

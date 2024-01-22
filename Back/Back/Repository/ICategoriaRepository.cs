using Back.Models;

namespace Back.Repository
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetListCat();
        Task<Categoria> GetCat(int Id);
        Task DeleteCat(Categoria categoria);
        Task<Categoria> AddCat(Categoria categoria);
        Task UpdateCat(Categoria categoria);
    }
}

using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AddCat(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task DeleteCat(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetListCat()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCat(int Id)
        {
            return await _context.Categorias.FindAsync(Id);
        }

        public async Task UpdateCat(Categoria categoria)
        {
            var catItem = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == categoria.Id);

            if (catItem != null)
            {
                catItem.NombreCa = categoria.NombreCa;
                



                await _context.SaveChangesAsync();
            }

        }
    }
}

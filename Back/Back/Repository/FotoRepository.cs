using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class FotoRepository : IFotoRepository
    {
        private readonly ApplicationDbContext _context;

        public FotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Foto> AddFo(Foto foto)
        {
            _context.Add(foto);
            await _context.SaveChangesAsync();
            return foto;
        }

        public async Task DeleteFo(Foto foto)
        {
            _context.Fotos.Remove(foto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Foto>> GetListFo()
        {
            return await _context.Fotos.ToListAsync();
        }

        public async Task<Foto> GetFo(int Id)
        {
            return await _context.Fotos.FindAsync(Id);
        }

        public async Task UpdateFo(Foto foto)
        {
            var foItem = await _context.Fotos.FirstOrDefaultAsync(x => x.Id == foto.Id);

            if (foItem != null)
            {
                foItem.NombreFo = foto.NombreFo;

                foItem.Data = foto.Data;



                await _context.SaveChangesAsync();
            }

        }
    }
}

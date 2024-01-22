using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Local> AddLoc(Local local)
        {
            _context.Add(local);
            await _context.SaveChangesAsync();
            return local;
        }

        public async Task DeleteLoc(Local local)
        {
            _context.Locals.Remove(local);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Local>> GetListLoc()
        {
            return await _context.Locals.ToListAsync();
        }

        public async Task<Local> GetLoc(int Id)
        {
            return await _context.Locals.FindAsync(Id);
        }

        public async Task UpdateLoc(Local local)
        {
            var locItem = await _context.Locals.FirstOrDefaultAsync(x => x.Id == local.Id);

            if (locItem != null)
            {
                locItem.NombreLo = local.NombreLo;
                locItem.DescripcionLo = local.DescripcionLo;
                locItem.DireccionLo = local.DireccionLo;
                locItem.Telefono = local.Telefono;
                locItem.Horario = local.Horario;
                locItem.Categoria = local.Categoria;









                await _context.SaveChangesAsync();
            }

        }
    }
}

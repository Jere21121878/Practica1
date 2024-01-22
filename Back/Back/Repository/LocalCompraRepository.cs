using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class LocalCompraRepository : ILocalCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LocalCompra> AddLC(LocalCompra localCompra)
        {
            _context.Add(localCompra);
            await _context.SaveChangesAsync();
            return localCompra;
        }

        public async Task DeleteLC(LocalCompra localCompra)
        {
            _context.LocalCompras.Remove(localCompra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LocalCompra>> GetListLC()
        {
            return await _context.LocalCompras.ToListAsync();
        }

        public async Task<LocalCompra> GetLC(int Id)
        {
            return await _context.LocalCompras.FindAsync(Id);
        }

        public async Task UpdateLC(LocalCompra localCompra)
        {
            var localCompraItem = await _context.LocalCompras.FirstOrDefaultAsync(x => x.Id == localCompra.Id);

            if (localCompraItem != null)
            {
               

                await _context.SaveChangesAsync();
            }

        }
    }
}

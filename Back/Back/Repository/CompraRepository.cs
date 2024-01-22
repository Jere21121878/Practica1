using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Compra> AddCom(Compra compra)
        {
            _context.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task DeleteCom(Compra compra)
        {
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Compra>> GetListCom()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<Compra> GetCom(int Id)
        {
            return await _context.Compras.FindAsync(Id);
        }

        public async Task UpdateCom(Compra compra)
        {
            var comItem = await _context.Compras.FirstOrDefaultAsync(x => x.Id == compra.Id);

            if (comItem != null)
            {
                comItem.Total = compra.Total;
                comItem.Fecha = compra.Fecha;
            


                await _context.SaveChangesAsync();
            }

        }
    }
}

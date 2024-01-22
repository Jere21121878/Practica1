using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public DetalleCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DetalleCompra> AddDC(DetalleCompra detalleCompra)
        {
            _context.Add(detalleCompra);
            await _context.SaveChangesAsync();
            return detalleCompra;
        }

        public async Task DeleteDC(DetalleCompra detalleCompra)
        {
            _context.DetalleCompras.Remove(detalleCompra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DetalleCompra>> GetListDC()
        {
            return await _context.DetalleCompras.ToListAsync();
        }

        public async Task<DetalleCompra> GetDC(int Id)
        {
            return await _context.DetalleCompras.FindAsync(Id);
        }

        public async Task UpdateDC(DetalleCompra detalleCompra)
        {
            var detalleCompraItem = await _context.DetalleCompras.FirstOrDefaultAsync(x => x.Id == detalleCompra.Id);

            if (detalleCompraItem != null)
            {
                detalleCompraItem.Cantidad = detalleCompra.Cantidad;
                detalleCompraItem.PrecioXUnidad = detalleCompra.PrecioXUnidad;



                await _context.SaveChangesAsync();
            }

        }
    }
}

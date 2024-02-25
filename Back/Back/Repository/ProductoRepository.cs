using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> AddPro(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task DeletePro(Producto producto)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetListPro()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetPro(int Id)
        {
            return await _context.Productos.FindAsync(Id);
        }

        public async Task UpdatePro(Producto producto)
        {
            var proItem = await _context.Productos.FirstOrDefaultAsync(x => x.Id == producto.Id);

            if (proItem != null)
            {
                proItem.NombrePro = producto.NombrePro;
                proItem.DescripcionPro = producto.DescripcionPro;
                proItem.PrecioVendido = producto.PrecioVendido;
                proItem.PrecioComprado = producto.PrecioComprado;

                proItem.CantidadPro = producto.CantidadPro;
                proItem.CategoriaP = producto.CategoriaP;



                await _context.SaveChangesAsync();
            }

        }

    }
}

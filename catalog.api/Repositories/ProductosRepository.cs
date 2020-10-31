using catalog.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace catalog.api.Repositories
{
    public class ProductosRepository
    {
        private readonly AppDbContext context;

        public ProductosRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await context.Productos.Where(x => x.Estado == 1).ToListAsync();
        }

        public async Task<int> Add(Producto producto)
        {
            context.Productos.Add(producto);
            return await context.SaveChangesAsync();
        }

        public async Task<Producto> GetById(int idProducto)
        {
            return await context.Productos.Where(x => x.Id == idProducto).FirstOrDefaultAsync();
        }

        public async Task<int> Remove(int idProducto)
        {
            var producto = context.Productos.FirstOrDefault(x => x.Id == idProducto);
            
            if (producto == null)
                return 0;
            else
                producto.Estado = 0;

            context.Attach(producto);
            context.Entry(producto).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(Producto producto)
        {
            try
            {
                context.Attach(producto);
                context.Entry(producto).State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
            
        }


    }
}

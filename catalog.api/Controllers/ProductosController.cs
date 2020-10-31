using AutoMapper;
using catalog.api.DTOs;
using catalog.api.Entities;
using catalog.api.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductosController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await new ProductosRepository(context).GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await new ProductosRepository(context).GetById(id);

            if (producto == null)
                return NotFound();

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoDTO productoDTO)
        {

            if (productoDTO == null)
                return NotFound();

            var producto = mapper.Map<Producto>(productoDTO);

            int save = await new ProductosRepository(context).Add(producto);
            
            if (save > 0)
                return Ok(new { messsage = "Saved!"});
            else
                return NotFound();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null)
                return NotFound();

            var producto = mapper.Map<Producto>(productoDTO);
            producto.Id = id;

            int save = await new ProductosRepository(context).Update(producto);
            
            if (save > 0)
                return Ok(new { messsage = "Updated!" });
            else
                return NotFound();

        }
        
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            int save = await new ProductosRepository(context).Remove(id);

            if (save > 0)
                return Ok(new { messsage = "Deleted!" });
            else
                return NotFound();
        }

    }
}

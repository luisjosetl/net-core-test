using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.DTOs
{
    public class ProductoDTO
    {
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal PorcDescuento { get; set; }
        public byte Estado { get; set; } = 1;
    }
}

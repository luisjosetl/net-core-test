using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.api.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PorcDescuento { get; set; }
        public byte Estado { get; set; }
    }
}

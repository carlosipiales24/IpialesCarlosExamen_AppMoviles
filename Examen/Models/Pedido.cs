using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Models
{
     class Pedido
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public double Total { get; set; }

        public int ClienteId { get; set; } // Foreign ke
    }
}

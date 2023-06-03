using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArtCarrito
    {
        public int IdItem { get; set; }

        public int Cantidad { get; set; }

        public Articulo oArticulo { get; set; }
    }
}

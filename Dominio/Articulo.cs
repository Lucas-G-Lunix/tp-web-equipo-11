﻿using System.Collections.Generic;
using System.ComponentModel;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }

        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Marca Marca { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }

        public List<string> ImagenURL { get; set; }

        public decimal Precio { get; set; }
    }
}

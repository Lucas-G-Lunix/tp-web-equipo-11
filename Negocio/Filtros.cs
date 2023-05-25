using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Filtros
    {
        public List<Articulo> filtrar(string campo, string criterio, string filtro, List<Articulo> listaArticulos)
        {
            /*
             cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");
             */
            switch (campo)
            {
                case "Nombre":
                    listaArticulos = filtrarNombre(criterio, filtro, listaArticulos);
                    break;
                case "Descripción":
                    listaArticulos = filtrarDescripcion(criterio, filtro, listaArticulos);
                    break;
                case "Marca":
                    listaArticulos = filtrarMarca(criterio, filtro, listaArticulos);
                    break;
                case "Categoria":
                    listaArticulos = filtrarCategoria(criterio, filtro, listaArticulos);
                    break;
                case "Precio":
                    listaArticulos = filtrarPrecio(criterio, filtro, listaArticulos);
                    break;
                default:
                    break;
            }

            return listaArticulos;
        }
        private List<Articulo> filtrarNombre(string criterio, string filtro, List<Articulo> listaArticulos)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (criterio)
            {
                case "Contiene":
                    listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));
                    break;
                case "Comienza con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToLower().StartsWith(filtro.ToLower()));
                    break;
                case "Termina con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToLower().EndsWith(filtro.ToLower()));
                    break;
                default:
                    break;
            }
            return listaFiltrada;
        }
        private List<Articulo> filtrarDescripcion(string criterio, string filtro, List<Articulo> listaArticulos)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (criterio)
            {
                case "Contiene":
                    listaFiltrada = listaArticulos.FindAll(x => x.Descripcion.ToLower().Contains(filtro.ToLower()));
                    break;
                case "Comienza con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Descripcion.ToLower().StartsWith(filtro.ToLower()));
                    break;
                case "Termina con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Descripcion.ToLower().EndsWith(filtro.ToLower()));
                    break;
                default:
                    break;
            }
            return listaFiltrada;
        }
        private List<Articulo> filtrarMarca(string criterio, string filtro, List<Articulo> listaArticulos)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (criterio)
            {
                case "Contiene":
                    listaFiltrada = listaArticulos.FindAll(x => x.Marca.Descripcion.ToLower().Contains(filtro.ToLower()));
                    break;
                case "Comienza con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Marca.Descripcion.ToLower().StartsWith(filtro.ToLower()));
                    break;
                case "Termina con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Marca.Descripcion.ToLower().EndsWith(filtro.ToLower()));
                    break;
                default:
                    break;
            }
            return listaFiltrada;
        }
        private List<Articulo> filtrarCategoria(string criterio, string filtro, List<Articulo> listaArticulos)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (criterio)
            {
                case "Contiene":
                    listaFiltrada = listaArticulos.FindAll(x => x.Categoria.Descripcion.ToLower().Contains(filtro.ToLower()));
                    break;
                case "Comienza con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Categoria.Descripcion.ToLower().StartsWith(filtro.ToLower()));
                    break;
                case "Termina con":
                    listaFiltrada = listaArticulos.FindAll(x => x.Categoria.Descripcion.ToLower().EndsWith(filtro.ToLower()));
                    break;
                default:
                    break;
            }
            return listaFiltrada;
        }
        private List<Articulo> filtrarPrecio(string criterio, string filtro, List<Articulo> listaArticulos)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (criterio)
            {
                case "Mayor a":
                    listaFiltrada = listaArticulos.FindAll(x => x.Precio > Convert.ToDecimal(filtro));
                    break;
                case "Menor a":
                    listaFiltrada = listaArticulos.FindAll(x => x.Precio < Convert.ToDecimal(filtro));
                    break;
                case "Igual a":
                    listaFiltrada = listaArticulos.FindAll(x => x.Precio == Convert.ToDecimal(filtro));
                    break;
                default:
                    break;
            }
            return listaFiltrada;
        }
    }
}

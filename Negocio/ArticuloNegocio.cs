using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            try
            {
                List<Articulo> lista = new List<Articulo>();
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT A.Id, Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdCategoria, A.IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria " +
                   "FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categoria();

                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    else
                    {
                        aux.Categoria.Descripcion = "Sin Categoria";
                    }

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    else
                    {
                        aux.Marca.Descripcion = "Sin Marca";
                    }

                    lista.Add(aux);
                }
                datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("SELECT IdArticulo, ImagenURL FROM IMAGENES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    foreach (Articulo item in lista)
                    {
                        if (item.Id == (int)datos.Lector["IdArticulo"])
                        {
                            if (item.ImagenURL == null)
                            {
                                item.ImagenURL = new List<string>();
                            }
                            item.ImagenURL.Add((string)datos.Lector["ImagenURL"]);
                        }
                    }
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Articulo art)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)" +
                    " VALUES ('" + art.Codigo + "', '" + art.Nombre + "', '" + art.Descripcion + "', @marcaId, @categoriaId, @precio)");
                datos.setearParametro("@marcaId", art.Marca.Id);
                datos.setearParametro("@categoriaId", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos = new AccesoDatos();
                art.Id = datos.ultimoId();
                datos.cerrarConexion();
                foreach (string imagen in art.ImagenURL)
                {
                    datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenURL) VALUES (" + art.Id + ", '" + imagen + "')");
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Articulo art)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("UPDATE ARTICULOS SET " +
                    "Codigo = '" + art.Codigo + "', Nombre = '" + art.Nombre + "', Descripcion = '" + art.Descripcion + "', IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @Precio WHERE Id = @id");
                if (art.Marca == null)
                {
                    datos.setearParametro("@idMarca", DBNull.Value);
                }
                else
                {
                    datos.setearParametro("@idMarca", art.Marca.Id);
                }

                if (art.Categoria == null)
                {
                    datos.setearParametro("@idCategoria", DBNull.Value);
                }
                else
                {
                    datos.setearParametro("@idCategoria", art.Categoria.Id);
                }

                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @id");
                datos.setearParametro("@id", art.Id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                foreach (string imagen in art.ImagenURL)
                {
                    datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenURL) VALUES (" + art.Id + ", '" + imagen + "')");
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

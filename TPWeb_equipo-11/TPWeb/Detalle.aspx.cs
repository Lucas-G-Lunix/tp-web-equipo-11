using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPWeb
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"].ToString());
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    Articulo seleccionado = negocio.buscarArt(id);

                    rpImagenes.DataSource = seleccionado.ImagenURL;
                    rpImagenes.DataBind();

                    lblCodigo.Text = seleccionado.Codigo;
                    lblNombre.Text = seleccionado.Nombre;
                    lblDescripcion.Text = seleccionado.Descripcion;
                    lblMarca.Text = seleccionado.Marca.Descripcion;
                    lblCategoria.Text = seleccionado.Categoria.Descripcion;
                    lblPrecio.Text = (Convert.ToInt32(seleccionado.Precio)).ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                ArtCarrito artCarrito = new ArtCarrito();
                artCarrito.oArticulo = new Articulo();
                int Id = int.Parse(Request.QueryString["Id"].ToString());

                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.listar();

                foreach (var item in lista)
                {
                    if (item.Id == Id)
                    {
                        artCarrito.oArticulo.Id = item.Id;
                        artCarrito.oArticulo.Codigo = item.Codigo;
                        artCarrito.oArticulo.ImagenURL = item.ImagenURL;
                        artCarrito.oArticulo.Nombre = item.Nombre;
                        artCarrito.oArticulo.Marca = item.Marca;
                        artCarrito.oArticulo.Precio = item.Precio;
                    }
                }
                /*List<ArtCarrito> ListaCarrito = (List<ArtCarrito>)Session["ListaCarrito"]; */
                List<ArtCarrito> ListaCarrito = ListaSessionCarrito();
                artCarrito.IdItem = ListaCarrito.Count;
                artCarrito.Cantidad = 1;
                bool existe = false;
                foreach (ArtCarrito item in ListaCarrito)
                {
                    if (item.oArticulo.Id == Id)
                    {
                        item.Cantidad++;
                        existe = true;
                    }
                }
                if (existe)
                {
                    Session["ListaCarrito"] = ListaCarrito;
                }
                else
                {
                    ListaCarrito.Add(artCarrito);
                    Session["ListaCarrito"] = ListaCarrito;
                }

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }


        private List<ArtCarrito> ListaSessionCarrito()
        {
            try
            {
                List<ArtCarrito> artCarritos = Session["ListaCarrito"] != null ?
              (List<ArtCarrito>)Session["ListaCarrito"] : new List<ArtCarrito>();
                return artCarritos;
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
                return null;
            }
        }
    }
}
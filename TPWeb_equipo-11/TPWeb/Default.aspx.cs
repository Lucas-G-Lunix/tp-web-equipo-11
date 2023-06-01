
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    List<Articulo> listaArticulos = articuloNegocio.listar();
                    rpCards.DataSource = listaArticulos;
                    rpCards.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void rpCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var dataItem = e.Item.DataItem as Articulo;
                    //Repeater childRepeater = (Repeater)e.Item.FindControl("rpCarousel");
                    if (dataItem != null)
                    {
                        // Find the child repeater within the parent repeater item
                        var childRepeater = e.Item.FindControl("rpCarousel") as Repeater;

                        if (childRepeater != null)
                        {
                            // Bind the child repeater with the data from the parent repeater
                            //List<string> listaImagenes = ;
                            // eliminamos la primera imagen
                            //listaImagenes.RemoveAt(0);
                            childRepeater.DataSource = dataItem.ImagenURL;
                            childRepeater.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtFiltrar.Text;
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = articuloNegocio.listar();

                List<Articulo> listaFiltrada;
                listaFiltrada = listaArticulos.FindAll(x =>
                    x.Nombre.ToLower().Contains(filtro.ToLower()));
                rpCards.DataSource = listaFiltrada;
                rpCards.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?Id=" + Id, false);
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            ArtCarrito nuevo = new ArtCarrito();
            int Id = int.Parse(((Button)sender).CommandArgument);

            Articulo art = new Articulo();
            ArticuloNegocio ArtNegocio = new ArticuloNegocio();
            List<Articulo> lista = ArtNegocio.listar();

            foreach (var item in lista)
            {
                if (item.Id == Id)
                {
                    nuevo.Id = item.Id;
                    nuevo.Codigo = item.Codigo;
                    nuevo.Nombre = item.Nombre;
                    nuevo.Precio = item.Precio;
                }
            }
            /*List<ArtCarrito> ListaCarrito = (List<ArtCarrito>)Session["ListaCarrito"]; */
            List<ArtCarrito> ListaCarrito = ListaSessionCarrito();
            ListaCarrito.Add(nuevo);
            Response.Redirect("Default.aspx");




        }

        private List<ArtCarrito> ListaSessionCarrito()
        {
            List<ArtCarrito> artCarritos = Session["ListaCarrito"] != null ?
              (List<ArtCarrito>)Session["ListaCarrito"] : new List<ArtCarrito>();
            return artCarritos;
        }

        protected void lblContador_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarritoCompra.aspx");
        }

    }
}
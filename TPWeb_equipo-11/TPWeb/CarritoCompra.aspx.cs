using Dominio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPWeb
{
    public partial class CarritoCompra2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ArtCarrito> listaArticulos = (List<ArtCarrito>)Session["ListaCarrito"];
                rpArticulos.DataSource = listaArticulos;
                rpArticulos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idItem = int.Parse(((LinkButton)sender).CommandArgument);
            List<ArtCarrito> listaArticulos = (List<ArtCarrito>)Session["ListaCarrito"];
            listaArticulos.RemoveAt(idItem);
            Session["ListaCarrito"] = listaArticulos;
            Response.Redirect("CarritoCompra.aspx");
        }

        protected void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            int idItem = int.Parse(((LinkButton)sender).CommandArgument);
            List<ArtCarrito> listaArticulos = (List<ArtCarrito>)Session["ListaCarrito"];
            foreach (ArtCarrito item in listaArticulos)
            {
                if (item.IdItem == idItem)
                {
                    if (item.Cantidad > 1)
                    {
                        item.Cantidad--;
                    }
                }
            }
            Session["ListaCarrito"] = listaArticulos;
            Response.Redirect("CarritoCompra.aspx");
        }

        protected void btnMasCantidad_Click(object sender, EventArgs e)
        {
            int idItem = int.Parse(((LinkButton)sender).CommandArgument);
            List<ArtCarrito> listaArticulos = (List<ArtCarrito>)Session["ListaCarrito"];
            foreach (ArtCarrito item in listaArticulos)
            {
                if (item.IdItem == idItem)
                {
                    item.Cantidad++;
                }
            }
            Session["ListaCarrito"] = listaArticulos;
            Response.Redirect("CarritoCompra.aspx");
        }
        protected void txtCantidadArticulos_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
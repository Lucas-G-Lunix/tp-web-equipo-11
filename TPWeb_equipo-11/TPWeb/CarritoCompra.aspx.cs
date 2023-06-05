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
                if (listaArticulos != null)
                {
                    rpArticulos.DataSource = listaArticulos;
                    rpArticulos.DataBind();
                    int totalPagar = 0;
                    foreach (ArtCarrito item in listaArticulos)
                    {
                        totalPagar += Convert.ToInt32(item.oArticulo.Precio) * item.Cantidad;
                    }
                    lblTotal.Text = "Total a Pagar: " + totalPagar.ToString() + "$";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                int idItem = int.Parse(((LinkButton)sender).CommandArgument);
                List<ArtCarrito> listaArticulos = (List<ArtCarrito>)Session["ListaCarrito"];
                if (idItem >= 0)
                {
                    listaArticulos.RemoveAt(idItem);
                }
                Session["ListaCarrito"] = listaArticulos;
                Response.Redirect("CarritoCompra.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }

        protected void btnMenosCantidad_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }

        protected void btnMasCantidad_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }
    }
}
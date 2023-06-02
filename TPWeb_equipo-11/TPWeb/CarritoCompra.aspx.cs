using Dominio;
using System;
using System.Collections.Generic;

namespace TPWeb
{
    public partial class CarritoCompra2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ArtCarrito> listaAriculos = (List<ArtCarrito>)Session["ListaCarrito"];
            dgvArticulos.DataSource = listaAriculos;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
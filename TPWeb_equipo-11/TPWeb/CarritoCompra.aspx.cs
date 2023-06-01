using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPWeb
{
    public partial class CarritoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaCarrito"] == null)
            {
                ArtCarritoNegocio negocio = new ArtCarritoNegocio();
                Session.Add("ListaCarrito", negocio.listar());

            }


            dgvArticulos.DataSource = Session["ListaCarrito"];
            dgvArticulos.DataBind();

            List<ArtCarrito> listaSession = new List<ArtCarrito>();
            listaSession = (List<ArtCarrito>)Session["ListaCarrito"];
            decimal total = 0;
            lblPrecio.Text = "TOTAL: $" + total;
        }


        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
     

        }
    }
}
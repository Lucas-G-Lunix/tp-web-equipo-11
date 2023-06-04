using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblCantElementosCarrito.Text = Session["ListaCarrito"] != null ?
              ((List<ArtCarrito>)Session["ListaCarrito"]).Count().ToString() : 0.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }
    }
}
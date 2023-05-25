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
    public partial class Default : System.Web.UI.Page
    {
		public List<Articulo> listaArticulos = null;
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				if (!IsPostBack)
				{
					ArticuloNegocio articuloNegocio = new ArticuloNegocio();
					listaArticulos = articuloNegocio.listar();
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
                        List<string> listaImagenes = dataItem.ImagenURL;
                        // eliminamos la primera imagen
                        listaImagenes.RemoveAt(0);
                        childRepeater.DataSource = listaImagenes;
                        childRepeater.DataBind();
                    }
                }
            }
        }
    }
}
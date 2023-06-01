using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            Response.Redirect("Default.aspx", false);
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            // Logica carrito
        }
    }
}
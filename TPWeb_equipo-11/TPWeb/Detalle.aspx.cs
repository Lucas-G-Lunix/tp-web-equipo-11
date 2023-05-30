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

                    lblCodigo.Text = "Codigo de Articulo: " + seleccionado.Codigo;
                    lblNombre.Text = "Nombre: " + seleccionado.Nombre;
                    lblDescripcion.Text = "Descripción: " + seleccionado.Descripcion;
                    lblMarca.Text = "Marca: " + seleccionado.Marca.Descripcion;
                    lblCategoria.Text = "Categoria: " + seleccionado.Categoria.Descripcion;
                    lblPrecio.Text = "Precio: " + seleccionado.Precio.ToString();
                }
            }
			catch (Exception ex)
			{
				Session.Add("Error", ex);
			}
        }
    }
}
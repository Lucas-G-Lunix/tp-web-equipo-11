﻿
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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
            try
            {
                string Id = ((Button)sender).CommandArgument;
                Response.Redirect("Detalle.aspx?Id=" + Id, false);
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
                int Id = int.Parse(((Button)sender).CommandArgument);

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

        protected void lblContador_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CarritoCompra.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("Error:", ex);
            }
        }

    }
}
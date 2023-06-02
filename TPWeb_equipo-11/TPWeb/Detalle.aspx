<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .carousel .carousel-inner {
            height: 500px;
        }

        .carousel-inner .carousel-item img {
            min-height: 200px;
        }

        @media(max-width:768px) {
            .carousel .carousel-inner {
                height: auto;
            }
        }
    </style>
    <section class="py-5">
        <div class="container px-4 px-lg-5 my-5">
            <div class="row gx-4 gx-lg-5 align-items-center">
                <div class="col-md-6">
                    <div class="carousel-inner">
                        <div id="carouselExample" class="carousel slide">
                            <div class="carousel-inner">
                                <asp:Repeater runat="server" ID="rpImagenes">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src="<%# Container.DataItem %>" class="d-block w-100" alt="..." onerror="this.onerror=null; this.src='imgs/image-not-found.jpg'">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="small mb-1">
                        <asp:Label runat="server" Text="" ID="lblMarca" CssClass="text-uppercase text-muted brand"></asp:Label>
                    </div>
                    <div class="small mb-1">
                        <asp:Label runat="server" Text="" ID="lblCategoria" CssClass="text-uppercase text-muted" />
                    </div>
                    <div class="small mb-1">
                        <asp:Label runat="server" Text="" ID="lblCodigo" CssClass="text-uppercase text-muted"></asp:Label>
                    </div>
                    <h1 class="display-5 fw-bolder">
                        <asp:Label runat="server" Text="" ID="lblNombre"></asp:Label></h1>
                    <div class="fs-5 mb-5">
                        <asp:Label runat="server" Text="" ID="lblPrecio"></asp:Label><span>$</span>
                    </div>
                    <p class="lead">
                        <asp:Label runat="server" Text="" ID="lblDescripcion"></asp:Label>
                    </p>
                    <div class="d-flex">
                        <asp:LinkButton ID="btnVolver" runat="server" CssClass="btn btn-danger w-50 text-center me-3" OnClick="btnVolver_Click">
                            <i class="fas fa-undo-alt"></i> Volver
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnAgregarCarrito" runat="server" CssClass="btn btn-success btn-agregar-carrito flex-shrink-0 w-50" OnClick="btnAgregarCarrito_Click">
                            <i class="fas fa-cart-plus"></i> Agregar al carrito
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>

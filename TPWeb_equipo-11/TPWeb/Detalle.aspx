<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row d-flex justify-content-center">
            <div class="col-md-10">
                <div class="card">
                    <div class="row">
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
                            <div class="product p-4">
                                <div class="mt-4 mb-3">
                                    <h1 class="text-uppercase">
                                        <asp:Label runat="server" Text="" ID="lblNombre"></asp:Label></h1>
                                    <asp:Label runat="server" Text="" ID="lblMarca" CssClass="text-uppercase text-muted brand"></asp:Label>
                                    <asp:Label runat="server" Text="" ID="lblCodigo" CssClass="text-uppercase text-muted d-block"></asp:Label>
                                    <asp:Label runat="server" Text="" ID="lblCategoria" CssClass="text-capitalize text-muted d-block"></asp:Label>
                                    <h3 class="text-uppercase">
                                        <asp:Label runat="server" Text="" ID="lblPrecio"></asp:Label><span>$</span></h3>
                                    <asp:Label runat="server" Text="" ID="lblDescripcion" CssClass="about"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

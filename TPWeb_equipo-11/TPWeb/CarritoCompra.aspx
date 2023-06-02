<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoCompra.aspx.cs" Inherits="TPWeb.CarritoCompra2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="h-100" style="background-color: #eee;">
        <div class="container h-100 py-5">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-10">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h3 class="fw-normal mb-0 text-black">Carrito</h3>
                    </div>

                    <asp:Repeater ID="rpArticulos" runat="server">
                        <HeaderTemplate>
                            <div class="card rounded-3 mb-4">
                                <div class="card-body p-4">
                                    <div class="row d-flex justify-content-between align-items-center">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-md-2 col-lg-2 col-xl-2">
                                <img
                                    src="<%# Eval("oArticulo.ImagenURL[0]") %>"
                                    class="img-fluid rounded-3" alt="..." onerror="this.onerror=null; this.src='imgs/image-not-found.jpg'">
                            </div>
                            <div class="col-md-3 col-lg-3 col-xl-3">
                                <p class="lead fw-normal mb-2"><%# Eval("oArticulo.Nombre") %></p>
                                <p><span class="text-muted">Codigo: </span><%# Eval("oArticulo.Codigo") %> <span class="text-muted">Marca: </span><%# Eval("oArticulo.Marca") %></p>
                            </div>
                            <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                <button class="btn btn-link px-2"
                                    onclick="this.parentNode.querySelector('input[type=number]').stepDown()">
                                    <i class="fas fa-minus"></i>
                                </button>

                                <input id="form1" min="0" name="quantity" value="1" type="number"
                                    class="form-control form-control-sm" />

                                <button class="btn btn-link px-2"
                                    onclick="this.parentNode.querySelector('input[type=number]').stepUp()">
                                    <i class="fas fa-plus"></i>
                                </button>
                            </div>
                            <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                <h5 class="mb-0">$<%# Convert.ToInt32(Eval("oArticulo.Precio")) %></h5>
                            </div>
                            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                <a href="#!" class="text-danger">
                                    <i class="bi bi-trash"></i>
                                </a>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                            </div>
                        </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <div class="card">
                        <div class="card-body">
                            <button type="button" class="btn btn-warning btn-block btn-lg">Proceed to Pay</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>

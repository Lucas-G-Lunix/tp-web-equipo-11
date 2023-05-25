﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rpCards" runat="server" OnItemDataBound="rpCards_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <div id="<%# Eval("Id") %>" class="carousel carousel-dark slide card-img-top">
                                <div class="carousel-inner">
                                    <div class="carousel-item active" data-bs-interval="10000">
                                        <img src="<%#Eval("ImagenURL[0]") %>" class="card-img-top d-block w-100" alt="...">
                                    </div>
                                    <asp:Repeater ID="rpCarousel" runat="server">
                                        <ItemTemplate>
                                            <div class="carousel-item" data-bs-interval="2000">
                                                <img src="<%# Container.DataItem %>" class="card-img-top d-block w-100" alt="...">
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#<%# Eval("Id") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Previous</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#<%# Eval("Id") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Next</span>
                                </button>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

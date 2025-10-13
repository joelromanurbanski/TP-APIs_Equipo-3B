<%@ Page Title="Elegir Producto" Language="C#" AutoEventWireup="true" CodeBehind="ElegirProducto.aspx.cs" Inherits="tp_web_equipo_3b.ElegirProducto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Elegí tu premio</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Elegí tu premio 🎁</h2>
            
            <asp:Repeater ID="repPremios" runat="server" 
                          OnItemCommand="repPremios_ItemCommand" 
                          OnItemDataBound="repPremios_ItemDataBound">
                <ItemTemplate>
                    <div class="card d-inline-block m-2" style="width: 18rem;">
                        
                        <!-- Imagen principal -->
                        <asp:Image ID="imgArticulo" runat="server" CssClass="card-img-top" 
                                   Style="height:200px; object-fit:contain;" />

                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>

                            <!-- ComboBox de imágenes -->
                            <asp:DropDownList ID="ddlImagenes" runat="server" 
                                              AutoPostBack="true" 
                                              CssClass="form-select mb-2"
                                              OnSelectedIndexChanged="ddlImagenes_SelectedIndexChanged">
                            </asp:DropDownList>

                            <!-- Botón de selección -->
                            <asp:Button ID="btnElegir" runat="server" Text="¡Quiero este!" CssClass="btn btn-primary w-100"
                                CommandName="Elegir" CommandArgument='<%# Eval("Id") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</body>
</html>

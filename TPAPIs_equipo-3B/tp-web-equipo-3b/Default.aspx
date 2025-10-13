<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web_equipo_3b.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Promo Ganá!</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card shadow p-4">
            <h3 class="mb-3 text-center">Promo Ganá!</h3>

            <div class="mb-3">
                <label for="txtVoucher" class="form-label">Ingresá el código de tu voucher!</label>
                <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control" placeholder="XXXXXXXXXXXXXXXX" />
            </div>

            <asp:Button ID="btnValidar" runat="server" Text="Siguiente" CssClass="btn btn-primary" OnClick="btnValidar_Click" />

            <br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</body>
</html>

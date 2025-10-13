<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioRegistrado.aspx.cs" Inherits="tp_web_equipo_3b.UsuarioRegistrado" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro Exitoso</title>
    <style>
        .contenedor {
            text-align: center;
            margin-top: 60px;
            font-size: 1.3rem;
            font-family: Arial, sans-serif;
        }
        .btn {
            margin-top: 20px;
            padding: 10px 20px;
            border: none;
            background-color: #007bff;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <asp:Label ID="lblMensaje" runat="server" Text="¡Registro exitoso!" />
            <br />
            <asp:Button ID="btnInicio" runat="server" Text="Volver al inicio" CssClass="btn" OnClick="btnInicio_Click" />
        </div>
    </form>
</body>
</html>

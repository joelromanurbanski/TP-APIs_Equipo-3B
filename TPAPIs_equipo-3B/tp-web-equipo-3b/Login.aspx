<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaGrupo15Progra3.WebForm2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        .login-container {
            width: 400px;
            margin: 100px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background: #f9f9f9;
        }
        .login-container h2 {
            text-align: center;
        }
        .login-container input {
            margin-bottom: 10px;
            width: 100%;
            padding: 8px;
        }
        .login-container button {
            width: 100%;
            padding: 10px;
            background: #007bff;
            border: none;
            color: white;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar Sesión</h2>
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario (Email):"></asp:Label>
            <asp:TextBox ID="LoginTextUsuario" runat="server"></asp:TextBox>

            <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña (DNI):"></asp:Label>
            <asp:TextBox ID="LoginTextContrasenia" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Button ID="LoginButton" runat="server" Text="Ingresar" OnClick="LoginButton_Click" />

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresaTusDatos.aspx.cs" Inherits="tp_web_equipo_3b.IngresaTusDatos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar tus Datos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ingresá tus datos</h2>

            <!-- Documento -->
            <asp:Label ID="lblDocumento" runat="server" Text="Documento (DNI):"></asp:Label>
            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server"
                ControlToValidate="txtDocumento" ErrorMessage="El documento es obligatorio."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDocumento" runat="server"
                ControlToValidate="txtDocumento" ValidationExpression="^\d+$"
                ErrorMessage="El documento solo puede contener números."
                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Nombre -->
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Apellido -->
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Email -->
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="Formato de email inválido."
                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Dirección -->
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                ControlToValidate="txtDireccion" ErrorMessage="La dirección es obligatoria."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Ciudad -->
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCiudad" runat="server"
                ControlToValidate="txtCiudad" ErrorMessage="La ciudad es obligatoria."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <br /><br />

            <!-- Código Postal -->
            <asp:Label ID="lblCP" runat="server" Text="Código Postal:"></asp:Label>
            <asp:TextBox ID="txtCP" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCP" runat="server"
                ControlToValidate="txtCP" ErrorMessage="El código postal es obligatorio."
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCP" runat="server"
                ControlToValidate="txtCP" ValidationExpression="^\d+$"
                ErrorMessage="El código postal solo puede contener números."
                ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <br /><br />

            <!-- Check de Términos -->
            <asp:CheckBox ID="chkTerminos" runat="server" Text=" Acepto los términos y condiciones" />
            <asp:CustomValidator ID="cvTerminos" runat="server"
                ErrorMessage="Debés aceptar los términos y condiciones."
                ForeColor="Red"
                OnServerValidate="cvTerminos_ServerValidate"></asp:CustomValidator>
            <br /><br />

            <!-- Botón Guardar -->
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <br /><br />

            <!-- Resumen de errores -->
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red"
                HeaderText="Por favor corregí los siguientes errores:" />

            <!-- Mensaje -->
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>

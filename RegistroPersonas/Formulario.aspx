<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="RegistroPersonas.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
  body {
  font-family: Arial, sans-serif;
  background: #f0f2f5;
  margin: 0;
  padding: 20px;
}

form {
  background: white;
  max-width: 1000px; 
  margin: 30px auto;
  padding: 30px 40px;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.2);
}

h2, h3 {
  text-align: center;
  color: #333;
}

label {
  font-weight: bold;
  display: block;
  margin-top: 100px;
}

input[type="text"], input[type="password"], input[type="email"], input[type="number"] {
  width: 100%;
  padding: 10px;
  margin-top: 5px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  font-size: 14px;
  transition: border-color 0.3s ease;
}

input[type="text"]:focus, input[type="password"]:focus, input[type="email"]:focus, input[type="number"]:focus {
  border-color: #007bff;
  outline: none;
}

input[type="submit"], button, .btn {
  background-color: #007bff;
  color: white !important;
  border: none;
  padding: 12px;
  font-size: 16px;
  border-radius: 4px;
  cursor: pointer;
  margin-top: 15px;
  width: 100%;
  transition: background-color 0.3s ease;
}

input[type="submit"]:hover, button:hover, .btn:hover {
  background-color: #0056b3;
}

.error {
  color: red;
  font-weight: bold;
  margin-bottom: 15px;
  text-align: center;
}



table {
  border-collapse: collapse;
  width: 100%;
  max-width: 600px; 
  margin: 20px auto 0 auto; 
  font-family: Arial, sans-serif;
  font-size: 14px;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
  border-radius: 6px;
  overflow: hidden;
}

th, td {
  text-align: left;
  padding: 12px;
  border-bottom: 1px solid #ddd;
}

th {
  background-color: #007bff;
  color: white;
  user-select: none;
}

tr:nth-child(even) {
  background-color: #f9f9f9;
}

tr:hover {
  background-color: #e6f0ff;
  cursor: pointer;
}

  }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Persona</h2>

<asp:Label ID="lblMensaje" runat="server" ForeColor="Red" /><br />

Nombre*: <asp:TextBox ID="txtNombre" runat="server" /><br />
Apellido Paterno*: <asp:TextBox ID="txtApellidoP" runat="server" /><br />
Apellido Materno: <asp:TextBox ID="txtApellidoM" runat="server" /><br />

<h3>Dirección</h3>

Calle*: <asp:TextBox ID="txtCalle" runat="server" /><br />
Número: <asp:TextBox ID="txtNumero" runat="server" /><br />
Colonia*: <asp:TextBox ID="txtColonia" runat="server" /><br />
CP*: <asp:TextBox ID="txtCP" runat="server" /><br />
Municipio: <asp:TextBox ID="txtMunicipio" runat="server" /><br />
Estado: <asp:TextBox ID="txtEstado" runat="server" /><br />

E-mail*: <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

<asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /><br />
<asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" /><br />
<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br /><br />


<<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
        <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
        <asp:BoundField DataField="Calle" HeaderText="Calle" />
        <asp:BoundField DataField="Numero" HeaderText="Número" />
        <asp:BoundField DataField="Colonia" HeaderText="Colonia" />
        <asp:BoundField DataField="CP" HeaderText="CP" />
        <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
        <asp:BoundField DataField="Email" HeaderText="E-mail" />
        <asp:CommandField ShowSelectButton="True" />
    </Columns>
</asp:GridView>


        </div>
    </form>
</body>
</html>

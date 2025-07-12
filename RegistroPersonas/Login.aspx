<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RegistroPersonas.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesión</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f0f2f5;
            margin: 0;
            padding: 20px;
        }
        form {
            background: white;
            max-width: 400px;
            margin: 50px auto;
            padding: 30px 40px;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.2);
        }
        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 25px;
        }
        label, input {
            display: block;
            width: 100%;
            margin-bottom: 15px;
        }
        input[type="text"], input[type="password"] {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }
        input[type="submit"], .btn {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 12px;
            font-size: 16px;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="submit"]:hover, .btn:hover {
            background-color: #0056b3;
        }
        .error {
            color: red;
            font-weight: bold;
            text-align: center;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Inicio de Sesión</h2>

        <asp:Label ID="lblError" runat="server" CssClass="error" /><br />

        <label for="txtUsuario">Usuario</label>
        <asp:TextBox ID="txtUsuario" runat="server" /><br />

        <label for="txtPassword">Contraseña</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn" />
    </form>
</body>
</html>

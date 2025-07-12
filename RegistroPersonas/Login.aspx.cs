using System;
using System.Data.SqlClient;

namespace RegistroPersonas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            string connStr = "Data Source=LAPTOP-9V52A0PG\\SQLEXPRESS;Initial Catalog=RegistroBD;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        Session["usuario"] = usuario;
                        Response.Redirect("Formulario.aspx");
                    }
                    else
                    {
                        lblError.Text = "Usuario o contraseña incorrectos.";
                    }
                }
            }
        }
    }
}

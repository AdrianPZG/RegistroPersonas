using System;
using System.Data;
using System.Data.SqlClient;

namespace RegistroPersonas
{
    public partial class Formulario : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        void CargarGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Personas";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO Personas 
                                    (Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, CP, Municipio, Estado, Email) 
                                     VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Calle, @Numero, @Colonia, @CP, @Municipio, @Estado, @Email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", txtApellidoP.Text);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", txtApellidoM.Text);
                    cmd.Parameters.AddWithValue("@Calle", txtCalle.Text);
                    cmd.Parameters.AddWithValue("@Numero", txtNumero.Text);
                    cmd.Parameters.AddWithValue("@Colonia", txtColonia.Text);
                    cmd.Parameters.AddWithValue("@CP", txtCP.Text);
                    cmd.Parameters.AddWithValue("@Municipio", txtMunicipio.Text);
                    cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = "Registro guardado.";
                LimpiarCampos();
                CargarGrid();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lblMensaje.Text = "Seleccione un registro para modificar.";
                return;
            }

            if (ValidarCampos())
            {
                int id = Convert.ToInt32(GridView1.SelectedDataKey.Value);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"UPDATE Personas SET
                                     Nombre=@Nombre,
                                     ApellidoPaterno=@ApellidoPaterno,
                                     ApellidoMaterno=@ApellidoMaterno,
                                     Calle=@Calle,
                                     Numero=@Numero,
                                     Colonia=@Colonia,
                                     CP=@CP,
                                     Municipio=@Municipio,
                                     Estado=@Estado,
                                     Email=@Email
                                     WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", txtApellidoP.Text);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", txtApellidoM.Text);
                    cmd.Parameters.AddWithValue("@Calle", txtCalle.Text);
                    cmd.Parameters.AddWithValue("@Numero", txtNumero.Text);
                    cmd.Parameters.AddWithValue("@Colonia", txtColonia.Text);
                    cmd.Parameters.AddWithValue("@CP", txtCP.Text);
                    cmd.Parameters.AddWithValue("@Municipio", txtMunicipio.Text);
                    cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMensaje.Text = "Registro modificado.";
                LimpiarCampos();
                CargarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                lblMensaje.Text = "Seleccione un registro para eliminar.";
                return;
            }

            int id = Convert.ToInt32(GridView1.SelectedDataKey.Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Personas WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMensaje.Text = "Registro eliminado.";
            LimpiarCampos();
            CargarGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedDataKey.Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Personas WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtApellidoP.Text = dr["ApellidoPaterno"].ToString();
                    txtApellidoM.Text = dr["ApellidoMaterno"].ToString();
                    txtCalle.Text = dr["Calle"].ToString();
                    txtNumero.Text = dr["Numero"].ToString();
                    txtColonia.Text = dr["Colonia"].ToString();
                    txtCP.Text = dr["CP"].ToString();
                    txtMunicipio.Text = dr["Municipio"].ToString();
                    txtEstado.Text = dr["Estado"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoP.Text) ||
                string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtColonia.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblMensaje.Text = "Por favor llena todos los campos obligatorios (*)";
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtColonia.Text = "";
            txtCP.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            txtEmail.Text = "";
            lblMensaje.Text = "";
            GridView1.SelectedIndex = -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_Sistemas_3
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            Listar();
            Limpiar();
        }
        private void dgvCargaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCliente.Text = dgvCargaCliente.CurrentRow.Cells[0].Value.ToString();
            txtDNI.Text = dgvCargaCliente.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgvCargaCliente.CurrentRow.Cells[2]. Value.ToString();
            txtNombre.Text = dgvCargaCliente.CurrentRow.Cells[3].Value.ToString();
            txtCalle.Text = dgvCargaCliente.CurrentRow.Cells[4].Value.ToString();
            txtAltura.Text = dgvCargaCliente.CurrentRow.Cells[5].Value.ToString();
            cboLocalidad.Text = dgvCargaCliente.CurrentRow.Cells[6].Value.ToString();
        }
        private void dgvCargaCliente_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea cargar el Cliente?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                if (txtDNI.Text != string.Empty)
                {
                    try
                    {
                        string Insertar = "INSERT INTO Cliente (DNI, Apellido, Nombre, Calle, Altura, Localidad) VALUES (@DNI, @Apellido,@Nombre, @Calle, @Altura, @Localidad)";
                        SqlCommand cmd1 = new SqlCommand(Insertar, Coneccion.Conectar());
                        cmd1.Parameters.AddWithValue("@DNI", txtDNI.Text);
                        cmd1.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        cmd1.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd1.Parameters.AddWithValue("@Calle", txtCalle.Text);
                        cmd1.Parameters.AddWithValue("@Altura", txtAltura.Text);
                        cmd1.Parameters.AddWithValue("@Localidad", cboLocalidad.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Cliente Cargado");
                        Listar();
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Debe ingresar el DNI");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea modificar este Cliente?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    string modificar = "UPDATE Cliente SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, Calle = @Calle, Altura = @Altura, Localidad = @Localidad WHERE IdCliente = @IdCliente";
                    SqlCommand cmd2 = new SqlCommand(modificar, Coneccion.Conectar());
                    cmd2.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                    cmd2.Parameters.AddWithValue("@DNI", txtDNI.Text);
                    cmd2.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd2.Parameters.AddWithValue("@Calle", txtCalle.Text);
                    cmd2.Parameters.AddWithValue("@Altura", txtAltura.Text);
                    cmd2.Parameters.AddWithValue("@Localidad", cboLocalidad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Cliente Modificado");
                    Listar();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea eliminar este Cliente?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                string eliminar = "DELETE FROM Cliente WHERE DNI=@DNI";
                SqlCommand cmd3 = new SqlCommand(eliminar, Coneccion.Conectar());
                cmd3.Parameters.AddWithValue("@DNI", txtDNI.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Cliente Eliminado");
                Listar();
                Limpiar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Listar()
        {
            string consulta = "select IdCliente 'Id Cliente', DNI, Apellido, Nombre, Calle, Altura, Localidad from Cliente";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvCargaCliente.DataSource = null;
            dgvCargaCliente.DataSource = ds.Tables[0];

            dgvCargaCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCargaCliente.RowHeadersVisible = false;
            dgvCargaCliente.Columns[0].Visible = false;
            dgvCargaCliente.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCargaCliente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCargaCliente.AllowUserToResizeColumns = false;
            dgvCargaCliente.AllowUserToResizeRows = false;
        }
        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtAltura.Text = string.Empty;
            cboLocalidad.SelectedIndex = 0;
            cboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            txtDNI.Focus();
        }
    }
}

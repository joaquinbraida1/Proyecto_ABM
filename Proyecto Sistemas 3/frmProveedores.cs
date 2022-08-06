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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent(); 
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            Listar();
            Limpiar();
        }
        private void dgvCargaProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProveedor.Text = dgvCargaProveedor.CurrentRow.Cells[0].Value.ToString();
            txtCUIT.Text = dgvCargaProveedor.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgvCargaProveedor.CurrentRow.Cells[2].Value.ToString();
            txtNombre.Text = dgvCargaProveedor.CurrentRow.Cells[3].Value.ToString();
            txtCalle.Text = dgvCargaProveedor.CurrentRow.Cells[4].Value.ToString();
            txtAltura.Text = dgvCargaProveedor.CurrentRow.Cells[5].Value.ToString();
            cboLocalidad.Text = dgvCargaProveedor.CurrentRow.Cells[6].Value.ToString();
        }
        private void dgvCargaProveedor_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea cargar el Proveedor?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                if (txtCUIT.Text != string.Empty)
                {
                    try
                    {
                        string Insertar = "INSERT INTO Proveedores (Cuit, Apellido, Nombre, Calle, Altura, Localidad) VALUES ( @Cuit, @Apellido, @Nombre, @Calle, @Altura, @Localidad)";
                        SqlCommand cmd1 = new SqlCommand(Insertar, Coneccion.Conectar());
                        cmd1.Parameters.AddWithValue("@Cuit", txtCUIT.Text);
                        cmd1.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        cmd1.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd1.Parameters.AddWithValue("@Calle", txtCalle.Text);
                        cmd1.Parameters.AddWithValue("@Altura", txtAltura.Text);
                        cmd1.Parameters.AddWithValue("@Localidad", cboLocalidad.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Proveedor Cargado");
                        Listar();
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Debe ingresar el CUIT");
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea modificar este Proveedor?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    string modificar = "UPDATE Proveedores SET Cuit = @Cuit, Apellido = @Apellido, Nombre = @Nombre, Calle = @Calle, Altura = @Altura, Localidad = @Localidad WHERE IdProveedores = @IdProveedores";
                    SqlCommand cmd2 = new SqlCommand(modificar, Coneccion.Conectar());
                    cmd2.Parameters.AddWithValue("@IdProveedores", txtIdProveedor.Text);
                    cmd2.Parameters.AddWithValue("@Cuit", txtCUIT.Text);
                    cmd2.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd2.Parameters.AddWithValue("@Calle", txtCalle.Text);
                    cmd2.Parameters.AddWithValue("@Altura", txtAltura.Text);
                    cmd2.Parameters.AddWithValue("@Localidad", cboLocalidad.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Proveedor Modificado");
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
            DialogResult resp = MessageBox.Show("¿Está seguro que desea eliminar este Proveedor?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                string eliminar = "DELETE FROM Proveedores WHERE Cuit=@Cuit";
                SqlCommand cmd3 = new SqlCommand(eliminar, Coneccion.Conectar());
                cmd3.Parameters.AddWithValue("@Cuit", txtCUIT.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Proveedor eliminado");
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
            string consulta = "select IdProveedores 'Id Proveedor', CUIT, Apellido, Nombre, Calle, Altura, Localidad from Proveedores";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvCargaProveedor.DataSource = null;
            dgvCargaProveedor.DataSource = ds.Tables[0];

            dgvCargaProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCargaProveedor.RowHeadersVisible = false;
            dgvCargaProveedor.Columns[0].Visible = false;
            dgvCargaProveedor.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCargaProveedor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCargaProveedor.AllowUserToResizeColumns = false;
            dgvCargaProveedor.AllowUserToResizeRows = false;
        }
        private void Limpiar()
        {
            txtIdProveedor.Text = string.Empty;
            txtCUIT.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtAltura.Text = string.Empty;
            cboLocalidad.SelectedIndex = 0;
            cboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCUIT.Focus();
        }
    }
}

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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            Listar();
            Limpiar();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProducto.Text = dgvRegProd.CurrentRow.Cells[0].Value.ToString();
            cboNombreProducto.Text = dgvRegProd.CurrentRow.Cells[1].Value.ToString();
            cboTalle.Text = dgvRegProd.CurrentRow.Cells[2].Value.ToString();
            cboColor.Text = dgvRegProd.CurrentRow.Cells[3].Value.ToString();
            cboManga.Text = dgvRegProd.CurrentRow.Cells[4].Value.ToString();
        }
        private void dgvRegProd_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea cargar este producto?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                if (txtProducto.Text != string.Empty)
                {
                    try
                    {
                        string Insertar = "INSERT INTO Producto (IdProducto, Descripcion_producto, Talle, Color, TipoManga) VALUES (@IdProducto, @Descripcion_producto, @Talle, @Color, @TipoManga)";
                        SqlCommand cmd1 = new SqlCommand(Insertar, Coneccion.Conectar());
                        cmd1.Parameters.AddWithValue("IdProducto", txtProducto.Text);
                        cmd1.Parameters.AddWithValue("@Descripcion_producto", cboNombreProducto.Text);
                        cmd1.Parameters.AddWithValue("@Talle", cboTalle.Text);
                        cmd1.Parameters.AddWithValue("@Color", cboColor.Text);
                        cmd1.Parameters.AddWithValue("@TipoManga", cboManga.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Producto Cargado");
                        Listar();
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else MessageBox.Show("Debe ingresar el Id de Producto");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea modificar este producto?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    string modificar = "UPDATE Producto SET Descripcion_producto=@Descripcion_producto, Talle=@Talle, Color=@Color, TipoManga=@TipoManga WHERE Idproducto=@Idproducto";
                    SqlCommand cmd2 = new SqlCommand(modificar, Coneccion.Conectar());
                    cmd2.Parameters.AddWithValue("@Idproducto", txtProducto.Text);
                    cmd2.Parameters.AddWithValue("@Descripcion_producto", cboNombreProducto.Text);
                    cmd2.Parameters.AddWithValue("@Talle", cboTalle.Text);
                    cmd2.Parameters.AddWithValue("@Color", cboColor.Text);
                    cmd2.Parameters.AddWithValue("@TipoManga", cboManga.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Producto Modificado");
                    Listar();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                string eliminar = "DELETE FROM Producto WHERE Idproducto=@Idproducto";
                SqlCommand cmd3 = new SqlCommand(eliminar, Coneccion.Conectar());
                cmd3.Parameters.AddWithValue("@Idproducto", txtProducto.Text);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Producto Eliminado");
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
            string consulta = "select IdProducto 'Id Producto', Descripcion_producto 'Descripción del producto', Talle, Color, TipoManga 'Tipo Manga' from Producto;";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvRegProd.DataSource = null;
            dgvRegProd.DataSource = ds.Tables[0];

            dgvRegProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegProd.RowHeadersVisible = false;
            //dgvRegProd.Columns[0].Visible = false;
            dgvRegProd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegProd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegProd.AllowUserToResizeColumns = false;
            dgvRegProd.AllowUserToResizeRows = false;
        }
        private void Limpiar()
        {
            txtProducto.Text = string.Empty;
            cboNombreProducto.SelectedIndex = 0;
            cboNombreProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTalle.SelectedIndex = 0;
            cboTalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.SelectedIndex = 0;
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboManga.SelectedIndex = 0;
            cboManga.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProducto.Focus();
        }
    }
}

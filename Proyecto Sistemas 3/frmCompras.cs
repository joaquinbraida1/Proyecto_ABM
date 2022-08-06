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
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            BuscarProducto();
            //Listar();
            //Limpiar();
        }
        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDetalle.Text = dgvCompras.CurrentRow.Cells[0].Value.ToString();
            txtIdProveedor.Text = dgvCompras.CurrentRow.Cells[1].Value.ToString();
            cboIdProducto.Text = dgvCompras.CurrentRow.Cells[2].Value.ToString();
            txtComprobante.Text = dgvCompras.CurrentRow.Cells[3].Value.ToString();
            txtProveedor.Text = dgvCompras.CurrentRow.Cells[4].Value.ToString();
            txtDescripcion.Text = dgvCompras.CurrentRow.Cells[5].Value.ToString();
            txtTalle.Text = dgvCompras.CurrentRow.Cells[6].Value.ToString();
            txtColor.Text = dgvCompras.CurrentRow.Cells[7].Value.ToString();
            txtManga.Text = dgvCompras.CurrentRow.Cells[8].Value.ToString();
            txtCantidad.Text = dgvCompras.CurrentRow.Cells[9].Value.ToString();
            dtpFecha.Text = dgvCompras.CurrentRow.Cells[10].Value.ToString();

        }
        private void dgvCompras_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmListSelectProveedor ofrm = new frmListSelectProveedor();
                ofrm.ShowDialog();
                txtIdProveedor.Text = ofrm.IdProveedores.ToString();
                string Apellido = ofrm.Apellido.ToString();
                string Nombre = ofrm.Nombre.ToString();
                txtProveedor.Text = Apellido + ", " + Nombre;
                txtCUIT.Text = ofrm.CUIT.ToString();
            }
            catch { }
        }
        private void cboIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarEnCombo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Today;
            if (txtIdProveedor.Text != string.Empty && cboIdProducto.SelectedIndex != -1 && txtCantidad.Text != string.Empty)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que los datos ingresados son correctos?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    if (dtpFecha.Value.Date >= Hoy)
                    {
                        try
                        {
                            AgregarCompra();
                            AgregarDetalleCompra();
                            MessageBox.Show("Registro cargado");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fecha invalida, no se puede seleccionar una fecha pasada", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un registro", "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtIdProveedor.Text != string.Empty && cboIdProducto.SelectedIndex != -1 && txtCantidad.Text != string.Empty)
            {
                DialogResult resp = MessageBox.Show("¿Está seguro que desea eliminar ese dato?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    string eliminar = "DELETE FROM DetalleCompra WHERE IdDetalleCompra = @IdDetalleCompra";
                    //"DELETE FROM RemitodeVenta WHERE IdRemVen = @IdRemVen";
                    SqlCommand cmd3 = new SqlCommand(eliminar, Coneccion.Conectar());
                    cmd3.Parameters.AddWithValue("@IdDetalleCompra", txtDetalle.Text);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Se elimino el registro seleccionado");
                    ListarCompra();
                    LimpiarCompra();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un registro", "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Limpiar();
            Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaTotalCompras oListar = new ListaTotalCompras();
            oListar.Show();
        }
        private void BuscarProducto()
        {
            string consulta = "select * from Producto";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboIdProducto.Items.Add(dr.GetInt32(0));
            }
        }
        private void BuscarEnCombo()
        {
            string consulta2 = "select * from Producto p where p.IdProducto = '" + cboIdProducto.Text + "'";
            SqlCommand cmd2 = new SqlCommand(consulta2, Coneccion.Conectar());
            SqlDataReader dr1 = cmd2.ExecuteReader();
            if (dr1.Read() == true)
            {
                txtDescripcion.Text = dr1["Descripcion_producto"].ToString();
                txtTalle.Text = dr1["Talle"].ToString();
                txtColor.Text = dr1["Color"].ToString();
                txtManga.Text = dr1["TipoManga"].ToString();
            }
        }
        private void AgregarCompra()
        {
            string InsertarCompra = "Insert into Compra (Fecha, IdProveedores) values (@Fecha, @IdProveedores)";
            SqlCommand cmd = new SqlCommand(InsertarCompra, Coneccion.Conectar());
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(dtpFecha.Text));
            cmd.Parameters.AddWithValue("@IdProveedores", txtIdProveedor.Text);
            cmd.ExecuteNonQuery();

            string sqlSentencia = "Select * From Compra where IdProveedores ='" + txtIdProveedor.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlSentencia, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtComprobante.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No existe el registro de compra");
            }
        }
        private void AgregarDetalleCompra()
        {
            String InsertarDetalle = "Insert into DetalleCompra (IdProducto, Cantidad, IdRegCom) values (@IdProducto, @Cantidad, @IdRegCom)";
            SqlCommand cmd2 = new SqlCommand(InsertarDetalle, Coneccion.Conectar());
            cmd2.Parameters.AddWithValue("@IdDetalleCompra", txtDetalle.Text);
            cmd2.Parameters.AddWithValue("@IdProducto", cboIdProducto.Text);
            cmd2.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd2.Parameters.AddWithValue("@IdRegCom", txtComprobante.Text);
            cmd2.ExecuteNonQuery();
            ListarCompra();
            LimpiarCompra();
        }

        private void ListarCompra()
        {
            string consulta = "select dc.IdDetalleCompra, c.IdProveedores, dc.IdProducto, dc.IdRegCom 'Registro Compra',pr.Apellido +', '+ pr.Nombre 'Nombre Completo', p.Descripcion_producto Producto, p.Talle, p.Color, p.TipoManga Manga, dc.Cantidad, c.Fecha from DetalleCompra dc inner join Compra c on dc.IdRegCom = c.IdRegCom inner join Proveedores pr on c.IdProveedores = pr.IdProveedores inner join Producto p on dc.IdProducto = p.IdProducto where dc.IdRegCom = '" + txtComprobante.Text + "'";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvCompras.DataSource = null;
            dgvCompras.DataSource = ds.Tables[0];

            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.Columns[0].Visible = false;
            dgvCompras.Columns[1].Visible = false;
            dgvCompras.Columns[2].Visible = false;
            //dgvCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCompras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCompras.AllowUserToResizeColumns = false;
            //dgvCompras.AllowUserToResizeRows = false;
        }
        private void Listar()
        {
            string consulta = "select c.IdRegCom 'Comprobante', c.IdProveedores 'ID Proveedor',pr.Apellido +', '+ pr.Nombre 'Nombre Completo', p.Descripcion_producto Producto,p.Talle, p.Color, p.TipoManga Manga, C.CantidadProducto Cantidad, c.Fecha from RegistroCompra C inner join RegistroProveedores pr on c.IdProveedores = pr.IdProveedores inner join RegistroProducto p on c.IdProducto = p.IdProducto";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvCompras.DataSource = null;
            dgvCompras.DataSource = ds.Tables[0];

            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.Columns[0].Visible = false;
            dgvCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCompras.AllowUserToResizeColumns = false;
            dgvCompras.AllowUserToResizeRows = false;
        }
        private void LimpiarCompra()
        {
            txtDescripcion.Text = string.Empty;
            txtTalle.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtManga.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            cboIdProducto.SelectedIndex = -1;
            cboIdProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdProducto.Focus();
        }
        private void Limpiar()
        {
            txtComprobante.Text = string.Empty;
            txtIdProveedor.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtTalle.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtManga.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCUIT.Text = string.Empty;
            cboIdProducto.SelectedIndex = 0;
            cboIdProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFecha.Value = DateTime.Today;
            dgvCompras.DataSource = null;
            txtIdProveedor.Focus();
        }


    }
}

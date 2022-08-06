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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            BuscarProducto();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDetalle.Text = dgvVentas.CurrentRow.Cells[0].Value.ToString();
            txtIdCliente.Text = dgvVentas.CurrentRow.Cells[1].Value.ToString();
            cboIdProducto.Text = dgvVentas.CurrentRow.Cells[2].Value.ToString();
            txtComprobante.Text = dgvVentas.CurrentRow.Cells[3].Value.ToString();
            txtCliente.Text = dgvVentas.CurrentRow.Cells[4].Value.ToString();
            txtDescripcion.Text = dgvVentas.CurrentRow.Cells[5].Value.ToString();
            txtTalle.Text = dgvVentas.CurrentRow.Cells[6].Value.ToString();
            txtColor.Text = dgvVentas.CurrentRow.Cells[7].Value.ToString();
            txtManga.Text = dgvVentas.CurrentRow.Cells[8].Value.ToString();
            txtCantidad.Text = dgvVentas.CurrentRow.Cells[9].Value.ToString();
            dtpFecha.Text = dgvVentas.CurrentRow.Cells[10].Value.ToString();
        }
        private void dgvVentas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmListSelectCliente ofrm = new frmListSelectCliente();
                ofrm.ShowDialog();
                txtIdCliente.Text = ofrm.IdCliente.ToString();
                txtCliente.Text = ofrm.Apellido.ToString() + ", " + ofrm.Nombre.ToString();
                txtDNI.Text = ofrm.DNI.ToString();
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
            if (txtIdCliente.Text != string.Empty && cboIdProducto.SelectedIndex != -1 && txtCantidad.Text != string.Empty)
            {
                DialogResult resp = MessageBox.Show("¿Estas seguro que los datos ingresados son correctos?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    if (dtpFecha.Value.Date >= Hoy)
                    {
                        try
                        {
                            AgregarVenta();
                            AgregarDetalleVenta();
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
            if(txtIdCliente.Text != string.Empty && cboIdProducto.SelectedIndex != -1 && txtCantidad.Text != string.Empty)
            { 
                DialogResult resp = MessageBox.Show("¿Está seguro que desea eliminar ese dato?", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    string eliminar = "DELETE FROM DetalleVenta WHERE IdDetalleVenta = @IdDetalleVenta";
                    //"DELETE FROM RemitodeVenta WHERE IdRemVen = @IdRemVen";
                    SqlCommand cmd3 = new SqlCommand(eliminar, Coneccion.Conectar());
                    cmd3.Parameters.AddWithValue("@IdDetalleVenta", txtDetalle.Text);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Se elimino el registro seleccionado");
                    ListarVenta();
                    LimpiarVenta();
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
            ListarTotalVentas oListar = new ListarTotalVentas();
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
        private void AgregarVenta()
        {
            string InsertarVenta = "Insert into Venta(Fecha, IdCliente) values (@Fecha, @IdCliente)";
            SqlCommand cmd = new SqlCommand(InsertarVenta, Coneccion.Conectar());
            //cmd.Parameters.AddWithValue("@IdRemVen", txtComprobante.Text);
            cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(dtpFecha.Text));
            cmd.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
            cmd.ExecuteNonQuery();

            string sqlSentencia = "Select * From Venta where IdCliente ='" + txtIdCliente.Text + "'";//+"and IdRemVen = '"+txtComprobante.Text+"'";
            SqlCommand cmd1 = new SqlCommand(sqlSentencia, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
                txtComprobante.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No existe el remito de venta");
            }
        }
        private void AgregarDetalleVenta()
        {
            String InsertarDetalle = "Insert into DetalleVenta(IdProducto, Cantidad, IdRemVen) values (@IdProducto, @Cantidad, @IdRemVen)";
            SqlCommand cmd2 = new SqlCommand(InsertarDetalle, Coneccion.Conectar());
            cmd2.Parameters.AddWithValue("@IdDetalleVenta", txtDetalle.Text);
            cmd2.Parameters.AddWithValue("@IdProducto", cboIdProducto.Text);
            cmd2.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd2.Parameters.AddWithValue("@IdRemVen", txtComprobante.Text);
            cmd2.ExecuteNonQuery();
            ListarVenta();
            LimpiarVenta();
        }

        private void ListarVenta()
        {
            string consulta = "select dv.IdDetalleVenta, v.IdCliente,dv.IdProducto, dv.IdRemVen 'Remito',c.Apellido +', '+ c.Nombre 'Nombre Completo', p.Descripcion_producto Producto, p.Talle, p.Color, p.TipoManga Manga,dv.Cantidad, v.Fecha from DetalleVenta dv inner join Venta v on dv.IdRemVen = v.IdRemVen inner join Cliente c on v.IdCliente = c.IdCliente inner join Producto p on dv.IdProducto = p.IdProducto where dv.IdRemVen = '" + txtComprobante.Text+"'"; 
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = ds.Tables[0];

            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.Columns[0].Visible = false;
            dgvVentas.Columns[1].Visible = false;
            dgvVentas.Columns[2].Visible = false;

        }
        private void Listar()
        {
            string consulta = "select dv.IdDetalleVenta, v.IdCliente,dv.IdProducto, dv.IdRemVen, dv.Cantidad, v.Fecha from DetalleVenta dv inner join Venta v on dv.IdRemVen = v.IdRemVen";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = ds.Tables[0];

            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.Columns[0].Visible = false;

        }
        private void LimpiarVenta()
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
            txtIdCliente.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtTalle.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtManga.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDNI.Text = string.Empty;
            cboIdProducto.SelectedIndex = -1;
            cboIdProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFecha.Value = DateTime.Today;
            dgvVentas.DataSource = null;
            txtIdCliente.Focus();
        }
    }
}

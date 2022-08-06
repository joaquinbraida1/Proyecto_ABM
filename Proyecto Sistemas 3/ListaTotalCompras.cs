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
    public partial class ListaTotalCompras : Form
    {
        public ListaTotalCompras()
        {
            InitializeComponent();
        }

        private void ListaTotalCompras_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvTotalCompras_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Listar()
        {
            string consulta = "select dc.IdDetalleCompra, c.IdProveedores, dc.IdProducto, dc.IdRegCom 'Registro Compra',pr.Apellido +', '+ pr.Nombre 'Nombre Completo', p.Descripcion_producto Producto, p.Talle, p.Color, p.TipoManga Manga, dc.Cantidad, c.Fecha from DetalleCompra dc inner join Compra c on dc.IdRegCom = c.IdRegCom inner join Proveedores pr on c.IdProveedores = pr.IdProveedores inner join Producto p on dc.IdProducto = p.IdProducto";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvTotalCompras.DataSource = null;
            dgvTotalCompras.DataSource = ds.Tables[0];

            dgvTotalCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotalCompras.RowHeadersVisible = false;
            dgvTotalCompras.Columns[0].Visible = false;
            dgvTotalCompras.Columns[1].Visible = false;
            dgvTotalCompras.Columns[2].Visible = false;
            //dgvTotalCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvTotalCompras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvTotalCompras.AllowUserToResizeColumns = false;
            //dgvTotalCompras.AllowUserToResizeRows = false;
        }

        private void dgvTotalCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

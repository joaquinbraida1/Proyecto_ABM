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
    public partial class ListarTotalVentas : Form
    {
        public ListarTotalVentas()
        {
            InitializeComponent();
        }
        private void dgvTotalVentas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ListarTotalVentas_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            string consulta = "select dv.IdDetalleVenta, v.IdCliente,dv.IdProducto, dv.IdRemVen 'Remito',c.Apellido +', '+ c.Nombre 'Nombre Completo', p.Descripcion_producto Producto, p.Talle, p.Color, p.TipoManga Manga,dv.Cantidad, v.Fecha from DetalleVenta dv inner join Venta v on dv.IdRemVen = v.IdRemVen inner join Cliente c on v.IdCliente = c.IdCliente inner join Producto p on dv.IdProducto = p.IdProducto";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvTotalVentas.DataSource = null;
            dgvTotalVentas.DataSource = ds.Tables[0];

            dgvTotalVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotalVentas.RowHeadersVisible = false;
            dgvTotalVentas.Columns[0].Visible = false;
            dgvTotalVentas.Columns[1].Visible = false;
            dgvTotalVentas.Columns[2].Visible = false;
           //dgvTotalVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvTotalVentas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvTotalVentas.AllowUserToResizeColumns = false;
            //dgvTotalVentas.AllowUserToResizeRows = false;
        }
    }
}

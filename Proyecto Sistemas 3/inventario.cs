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
using Proyecto_Sistemas_3;

namespace Trabajo_de_Sistemas3
{
    public partial class inventario : Form
    {
        public inventario()
        {
            InitializeComponent();
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            Coneccion.Conectar();
            Listar();

        }

        private void Listar()
        {
            string consulta = "select DISTINCT c.Idproducto,a.Descripcion_producto, a.Talle, a.Color, a.TipoManga,( select SUM(Cantidad) from DetalleCompra as TotalCompra Where IdProducto = a.Idproducto),( select SUM(Cantidad) from DetalleVenta as TotalVenta Where IdProducto = a.Idproducto), ( select SUM(Cantidad) from DetalleCompra  as TotalCompra Where IdProducto = a.Idproducto) - ( select SUM(Cantidad) from DetalleVenta as TotalVenta Where IdProducto = a.Idproducto) from Producto a , DetalleVenta c, DetalleCompra b where c.IdProducto = a.Idproducto and c.IdProducto =b.IdProducto order by c.IdProducto,a.Descripcion_producto, a.Talle, a.Color, a.TipoManga";
            SqlCommand cmd = new SqlCommand(consulta, Coneccion.Conectar());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvinvventario1.DataSource = null;
            dgvinvventario1.DataSource = ds.Tables[0];
            dgvinvventario1.Columns[1].HeaderText = "Descripcion del Producto";
            dgvinvventario1.Columns[5].HeaderText = "Ingreso de Stock";  // cambia el nombre de la columna 5 //
            dgvinvventario1.Columns[6].HeaderText = "Egreso de Stock";
            dgvinvventario1.Columns[7].HeaderText = "Stock Final";


            dgvinvventario1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvinvventario1.RowHeadersVisible = false;
            dgvinvventario1.Columns[0].Visible = false;
            dgvinvventario1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvinvventario1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvinvventario1.AllowUserToResizeColumns = false;
            dgvinvventario1.AllowUserToResizeRows = false;
        }

    private void ingresostock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaTotalCompras oListaTotalCompras = new ListaTotalCompras();
            oListaTotalCompras.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListarTotalVentas oListarTotalVentas = new ListarTotalVentas();
            oListarTotalVentas.Show();
        }
    }
}

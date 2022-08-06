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
    public partial class frmListSelectProveedor : Form
    {
        string conectionString = "Data Source=JOAQUIN\\SQLEXPRESS01;Initial Catalog=Rayosan2;Integrated Security=True";
        public string IdProveedores { get; set; }
        public string CUIT { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Localidad { get; set; }

        public frmListSelectProveedor()
        {
            InitializeComponent();
        }

        private void frmListSelectProveedor_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            string sqlSentencia = "select IdProveedores 'Id Proveedor',CUIT, Apellido, Nombre, Calle, Altura, Localidad from Proveedores";
            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;
            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);
            sqlCnn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
            sqlCnn.Close();
            dgvListProveedores.DataSource = null;
            dgvListProveedores.DataSource = ds.Tables[0];
        }

        private void dgvListProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdProveedores = dgvListProveedores.Rows[e.RowIndex].Cells[0].Value.ToString();
            CUIT = dgvListProveedores.Rows[e.RowIndex].Cells[1].Value.ToString();
            Apellido = dgvListProveedores.Rows[e.RowIndex].Cells[2].Value.ToString();
            Nombre = dgvListProveedores.Rows[e.RowIndex].Cells[3].Value.ToString();
            Calle = dgvListProveedores.Rows[e.RowIndex].Cells[4].Value.ToString();
            Altura = dgvListProveedores.Rows[e.RowIndex].Cells[5].Value.ToString();
            Localidad = dgvListProveedores.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.Close();
        }
    }
}

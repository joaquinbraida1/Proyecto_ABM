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
    public partial class frmListSelectCliente : Form
    {
        string conectionString = "Data Source=JOAQUIN\\SQLEXPRESS01;Initial Catalog=Rayosan2;Integrated Security=True";
        public string IdCliente { get; set; }
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Localidad { get; set; }
        public frmListSelectCliente()
        {
            InitializeComponent();
        }

        private void frmListSelectCliente_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void Listar()
        {
            string sqlSentencia = "select IdCliente 'Id Cliente',DNI,Apellido, Nombre, Calle, Altura, Localidad from Cliente";
            SqlConnection sqlCnn = new SqlConnection();
            sqlCnn.ConnectionString = conectionString;
            SqlCommand sqlComm = new SqlCommand(sqlSentencia, sqlCnn);
            sqlCnn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);
            sqlCnn.Close();
            dgvListClientes.DataSource = null;
            dgvListClientes.DataSource = ds.Tables[0];
        }

        private void dgvListClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdCliente = dgvListClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            DNI = dgvListClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            Apellido = dgvListClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            Nombre = dgvListClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            Calle = dgvListClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            Altura = dgvListClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
            Localidad = dgvListClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_de_Sistemas3;

namespace Proyecto_Sistemas_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores ofrmProveedores = new frmProveedores();
            ofrmProveedores.MdiParent = this;
            ofrmProveedores.Show();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes ofrmClientes = new frmClientes();
            ofrmClientes.MdiParent = this;
            ofrmClientes.Show();
        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto ofrmProducto = new frmProducto();
            ofrmProducto.MdiParent = this;
            ofrmProducto.Show();
        }

        private void registrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompras ofrmCompras = new frmCompras();
            ofrmCompras.MdiParent = this;
            ofrmCompras.Show();
        }

        private void registrarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas ofrmVentas = new frmVentas();
            ofrmVentas.MdiParent = this;
            ofrmVentas.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void verAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventario oinventario = new inventario();
            oinventario.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

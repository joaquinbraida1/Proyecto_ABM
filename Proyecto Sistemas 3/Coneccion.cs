using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_Sistemas_3
{
    class Coneccion
    {
        public static SqlConnection Conectar()
        {
            string conectionString = "Data Source=JOAQUIN\\SQLEXPRESS01;Initial Catalog=Rayosan2;Integrated Security=True";
            SqlConnection sqlCnn = new SqlConnection();

            // no olvidar poner la conexion en proyecto, propiedades, configuracion, string usuario conexion en modo string usuario//
            // no olvidar modificar la conexiones en  frmListSelectCliente y en frmListSelectProveedor //

            try
            {
                sqlCnn.ConnectionString = conectionString;
                if (sqlCnn.State.Equals(ConnectionState.Open))
                    sqlCnn.Close();
                else
                    sqlCnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sqlCnn;
        }
    }
}

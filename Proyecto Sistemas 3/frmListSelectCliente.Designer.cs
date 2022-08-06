
namespace Proyecto_Sistemas_3
{
    partial class frmListSelectCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListClientes
            // 
            this.dgvListClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListClientes.Location = new System.Drawing.Point(0, 0);
            this.dgvListClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvListClientes.Name = "dgvListClientes";
            this.dgvListClientes.RowHeadersWidth = 51;
            this.dgvListClientes.Size = new System.Drawing.Size(881, 357);
            this.dgvListClientes.TabIndex = 0;
            this.dgvListClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListClientes_CellDoubleClick);
            // 
            // frmListSelectCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 357);
            this.Controls.Add(this.dgvListClientes);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListSelectCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Clientes";
            this.Load += new System.EventHandler(this.frmListSelectCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListClientes;
    }
}
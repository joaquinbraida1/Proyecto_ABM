
namespace Proyecto_Sistemas_3
{
    partial class ListarTotalVentas
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
            this.dgvTotalVentas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTotalVentas
            // 
            this.dgvTotalVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalVentas.Location = new System.Drawing.Point(0, 0);
            this.dgvTotalVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTotalVentas.Name = "dgvTotalVentas";
            this.dgvTotalVentas.RowHeadersWidth = 51;
            this.dgvTotalVentas.Size = new System.Drawing.Size(1345, 332);
            this.dgvTotalVentas.TabIndex = 0;
            this.dgvTotalVentas.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvTotalVentas_ColumnAdded);
            // 
            // ListarTotalVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 332);
            this.Controls.Add(this.dgvTotalVentas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListarTotalVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total de Ventas";
            this.Load += new System.EventHandler(this.ListarTotalVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTotalVentas;
    }
}
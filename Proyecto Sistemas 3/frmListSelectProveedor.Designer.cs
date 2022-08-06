
namespace Proyecto_Sistemas_3
{
    partial class frmListSelectProveedor
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
            this.dgvListProveedores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListProveedores
            // 
            this.dgvListProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListProveedores.Location = new System.Drawing.Point(0, 0);
            this.dgvListProveedores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvListProveedores.Name = "dgvListProveedores";
            this.dgvListProveedores.RowHeadersWidth = 51;
            this.dgvListProveedores.Size = new System.Drawing.Size(881, 357);
            this.dgvListProveedores.TabIndex = 0;
            this.dgvListProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListProveedores_CellDoubleClick);
            // 
            // frmListSelectProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 357);
            this.Controls.Add(this.dgvListProveedores);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListSelectProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Proveedores";
            this.Load += new System.EventHandler(this.frmListSelectProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListProveedores;
    }
}
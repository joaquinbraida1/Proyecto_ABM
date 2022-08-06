
namespace Proyecto_Sistemas_3
{
    partial class ListaTotalCompras
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
            this.dgvTotalCompras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTotalCompras
            // 
            this.dgvTotalCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalCompras.Location = new System.Drawing.Point(0, 0);
            this.dgvTotalCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTotalCompras.Name = "dgvTotalCompras";
            this.dgvTotalCompras.RowHeadersWidth = 51;
            this.dgvTotalCompras.Size = new System.Drawing.Size(1067, 554);
            this.dgvTotalCompras.TabIndex = 0;
            this.dgvTotalCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotalCompras_CellContentClick);
            this.dgvTotalCompras.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvTotalCompras_ColumnAdded);
            // 
            // ListaTotalCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvTotalCompras);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListaTotalCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total de Compras";
            this.Load += new System.EventHandler(this.ListaTotalCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTotalCompras;
    }
}
namespace Trabajo_de_Sistemas3
{
    partial class inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inventario));
            this.dgvinvventario1 = new System.Windows.Forms.DataGridView();
            this.ingresostock = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinvventario1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvinvventario1
            // 
            this.dgvinvventario1.AllowUserToDeleteRows = false;
            this.dgvinvventario1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvinvventario1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvinvventario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinvventario1.Location = new System.Drawing.Point(12, 2);
            this.dgvinvventario1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvinvventario1.Name = "dgvinvventario1";
            this.dgvinvventario1.ReadOnly = true;
            this.dgvinvventario1.RowHeadersWidth = 51;
            this.dgvinvventario1.RowTemplate.Height = 29;
            this.dgvinvventario1.Size = new System.Drawing.Size(784, 235);
            this.dgvinvventario1.TabIndex = 0;
            // 
            // ingresostock
            // 
            this.ingresostock.AutoSize = true;
            this.ingresostock.Location = new System.Drawing.Point(12, 249);
            this.ingresostock.Name = "ingresostock";
            this.ingresostock.Size = new System.Drawing.Size(189, 16);
            this.ingresostock.TabIndex = 2;
            this.ingresostock.TabStop = true;
            this.ingresostock.Text = "Ver aqui los Ingresos de Stock";
            this.ingresostock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ingresostock_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(224, 249);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 16);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ver aqui los Egresos de Stock";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 272);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ingresostock);
            this.Controls.Add(this.dgvinvventario1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Almacen";
            this.Load += new System.EventHandler(this.inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinvventario1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvinvventario1;
        private System.Windows.Forms.LinkLabel ingresostock;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
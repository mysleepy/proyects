namespace MySleepy
{
    partial class AddNuevoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNuevoArticulo));
            this.nStock = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.cboMedida = new System.Windows.Forms.ComboBox();
            this.cboComposicion = new System.Windows.Forms.ComboBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblComposicion = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nStock)).BeginInit();
            this.SuspendLayout();
            // 
            // nStock
            // 
            this.nStock.Location = new System.Drawing.Point(95, 125);
            this.nStock.Name = "nStock";
            this.nStock.Size = new System.Drawing.Size(100, 20);
            this.nStock.TabIndex = 33;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(51, 130);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(38, 13);
            this.lblStock.TabIndex = 32;
            this.lblStock.Text = "Stock:";
            // 
            // cboMedida
            // 
            this.cboMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedida.FormattingEnabled = true;
            this.cboMedida.Location = new System.Drawing.Point(309, 76);
            this.cboMedida.Name = "cboMedida";
            this.cboMedida.Size = new System.Drawing.Size(121, 21);
            this.cboMedida.TabIndex = 31;
            // 
            // cboComposicion
            // 
            this.cboComposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComposicion.FormattingEnabled = true;
            this.cboComposicion.Location = new System.Drawing.Point(309, 31);
            this.cboComposicion.Name = "cboComposicion";
            this.cboComposicion.Size = new System.Drawing.Size(121, 21);
            this.cboComposicion.TabIndex = 30;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(95, 34);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(100, 20);
            this.txtReferencia.TabIndex = 20;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(30, 37);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 29;
            this.lblReferencia.Text = "Referencia:";
            // 
            // lblComposicion
            // 
            this.lblComposicion.AutoSize = true;
            this.lblComposicion.Location = new System.Drawing.Point(236, 34);
            this.lblComposicion.Name = "lblComposicion";
            this.lblComposicion.Size = new System.Drawing.Size(70, 13);
            this.lblComposicion.TabIndex = 28;
            this.lblComposicion.Text = "Composicion:";
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Location = new System.Drawing.Point(258, 81);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(45, 13);
            this.lblMedida.TabIndex = 27;
            this.lblMedida.Text = "Medida:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(247, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(146, 183);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(75, 23);
            this.btnAnadir.TabIndex = 25;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(95, 78);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 21;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(45, 85);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 24;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(309, 126);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 22;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(266, 132);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 23;
            this.lblPrecio.Text = "Precio:";
            // 
            // AddNuevoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 235);
            this.ControlBox = false;
            this.Controls.Add(this.nStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.cboMedida);
            this.Controls.Add(this.cboComposicion);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.lblComposicion);
            this.Controls.Add(this.lblMedida);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNuevoArticulo";
            this.Text = "Nuevo Articulo";
            this.Load += new System.EventHandler(this.AddNuevoArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.ComboBox cboMedida;
        private System.Windows.Forms.ComboBox cboComposicion;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblComposicion;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;

    }
}
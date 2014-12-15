namespace MySleepy
{
    partial class ArticulosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticulosForm));
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMedida = new System.Windows.Forms.ComboBox();
            this.rbNoEliminados = new System.Windows.Forms.RadioButton();
            this.rbEliminados = new System.Windows.Forms.RadioButton();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDARTICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(490, 159);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 20);
            this.txtCantidad.TabIndex = 45;
            this.txtCantidad.Visible = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(410, 161);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 44;
            this.lblCantidad.Text = "Cantidad:";
            this.lblCantidad.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMedida);
            this.groupBox1.Controls.Add(this.rbNoEliminados);
            this.groupBox1.Controls.Add(this.rbEliminados);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.lblMedida);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtReferencia);
            this.groupBox1.Controls.Add(this.lblReferencia);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 100);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // cbMedida
            // 
            this.cbMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedida.FormattingEnabled = true;
            this.cbMedida.Location = new System.Drawing.Point(325, 20);
            this.cbMedida.Name = "cbMedida";
            this.cbMedida.Size = new System.Drawing.Size(153, 21);
            this.cbMedida.TabIndex = 40;
            this.cbMedida.SelectedIndexChanged += new System.EventHandler(this.cbMedida_SelectedIndexChanged);
            // 
            // rbNoEliminados
            // 
            this.rbNoEliminados.AutoSize = true;
            this.rbNoEliminados.Checked = true;
            this.rbNoEliminados.Location = new System.Drawing.Point(511, 55);
            this.rbNoEliminados.Name = "rbNoEliminados";
            this.rbNoEliminados.Size = new System.Drawing.Size(92, 17);
            this.rbNoEliminados.TabIndex = 33;
            this.rbNoEliminados.TabStop = true;
            this.rbNoEliminados.Text = "No Eliminados";
            this.rbNoEliminados.UseVisualStyleBackColor = true;
            this.rbNoEliminados.CheckedChanged += new System.EventHandler(this.rbNoEliminados_CheckedChanged);
            this.rbNoEliminados.Click += new System.EventHandler(this.rbNoEliminados_Click);
            // 
            // rbEliminados
            // 
            this.rbEliminados.AutoSize = true;
            this.rbEliminados.Location = new System.Drawing.Point(511, 25);
            this.rbEliminados.Name = "rbEliminados";
            this.rbEliminados.Size = new System.Drawing.Size(75, 17);
            this.rbEliminados.TabIndex = 32;
            this.rbEliminados.TabStop = true;
            this.rbEliminados.Text = "Eliminados";
            this.rbEliminados.UseVisualStyleBackColor = true;
            this.rbEliminados.CheckedChanged += new System.EventHandler(this.rbEliminados_CheckedChanged);
            this.rbEliminados.Click += new System.EventHandler(this.rbEliminados_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(325, 67);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(153, 20);
            this.txtPrecio.TabIndex = 31;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyUp);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(259, 70);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 30;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Location = new System.Drawing.Point(257, 25);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(45, 13);
            this.lblMedida.TabIndex = 28;
            this.lblMedida.Text = "Medida:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::MySleepy.Properties.Resources.prestamos;
            this.btnLimpiar.Location = new System.Drawing.Point(640, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(61, 58);
            this.btnLimpiar.TabIndex = 39;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(74, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(153, 20);
            this.txtNombre.TabIndex = 27;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(8, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 26;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(74, 22);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(153, 20);
            this.txtReferencia.TabIndex = 25;
            this.txtReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferencia_KeyPress);
            this.txtReferencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReferencia_KeyUp);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(6, 25);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 24;
            this.lblReferencia.Text = "Referencia:";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvArticulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origen,
            this.Nombre,
            this.Destino,
            this.Texto,
            this.Telefono,
            this.IDARTICULO});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Black", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArticulos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvArticulos.GridColor = System.Drawing.Color.LightSalmon;
            this.dgvArticulos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvArticulos.Location = new System.Drawing.Point(24, 224);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersVisible = false;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(715, 187);
            this.dgvArticulos.TabIndex = 41;
            this.dgvArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellDoubleClick);
            // 
            // Origen
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Origen.DefaultCellStyle = dataGridViewCellStyle2;
            this.Origen.FillWeight = 71.06599F;
            this.Origen.HeaderText = "Ref.Articulo";
            this.Origen.Name = "Origen";
            this.Origen.ReadOnly = true;
            // 
            // Nombre
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Destino
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Destino.DefaultCellStyle = dataGridViewCellStyle4;
            this.Destino.FillWeight = 58.28161F;
            this.Destino.HeaderText = "Composicion";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            // 
            // Texto
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Texto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Texto.FillWeight = 61.92574F;
            this.Texto.HeaderText = "Medida";
            this.Texto.Name = "Texto";
            this.Texto.ReadOnly = true;
            // 
            // Telefono
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Telefono.DefaultCellStyle = dataGridViewCellStyle6;
            this.Telefono.FillWeight = 94.99262F;
            this.Telefono.HeaderText = "Precio";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // IDARTICULO
            // 
            this.IDARTICULO.HeaderText = "IDARTICULO";
            this.IDARTICULO.Name = "IDARTICULO";
            this.IDARTICULO.ReadOnly = true;
            this.IDARTICULO.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Para añadir articulos, doble click sobre la tabla Articulos";
            this.label1.Visible = false;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Enabled = false;
            this.btnRestaurar.Image = global::MySleepy.Properties.Resources.restaurar;
            this.btnRestaurar.Location = new System.Drawing.Point(318, 138);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(61, 58);
            this.btnRestaurar.TabIndex = 42;
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::MySleepy.Properties.Resources.Door_converted;
            this.btnSalir.Location = new System.Drawing.Point(721, 436);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(63, 52);
            this.btnSalir.TabIndex = 40;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::MySleepy.Properties.Resources.papelera_de_reciclaje;
            this.btnBorrar.Location = new System.Drawing.Point(223, 138);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(61, 58);
            this.btnBorrar.TabIndex = 38;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::MySleepy.Properties.Resources.adwords_editor_128;
            this.btnModificar.Location = new System.Drawing.Point(134, 138);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(61, 58);
            this.btnModificar.TabIndex = 37;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Image = global::MySleepy.Properties.Resources.mas;
            this.btnAñadir.Location = new System.Drawing.Point(46, 138);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(61, 58);
            this.btnAñadir.TabIndex = 36;
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // ArticulosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArticulosForm";
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.ArticulosForm_Load);
            this.Shown += new System.EventHandler(this.ArticulosForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNoEliminados;
        private System.Windows.Forms.RadioButton rbEliminados;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.ComboBox cbMedida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDARTICULO;

    }
}
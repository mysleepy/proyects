namespace MySleepy
{
    partial class Proveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEA = new System.Windows.Forms.ComboBox();
            this.rbEliminados = new System.Windows.Forms.RadioButton();
            this.rbNoEliminados = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtCIFNIF = new System.Windows.Forms.TextBox();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.IDPROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbEA);
            this.groupBox1.Controls.Add(this.rbEliminados);
            this.groupBox1.Controls.Add(this.rbNoEliminados);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtCIFNIF);
            this.groupBox1.Controls.Add(this.lblPoblacion);
            this.groupBox1.Location = new System.Drawing.Point(37, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 123);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::MySleepy.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(707, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 58);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Empresa/Autonomo:";
            // 
            // cbEA
            // 
            this.cbEA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEA.FormattingEnabled = true;
            this.cbEA.Items.AddRange(new object[] {
            "Empresa",
            "Autonomo"});
            this.cbEA.Location = new System.Drawing.Point(362, 37);
            this.cbEA.Name = "cbEA";
            this.cbEA.Size = new System.Drawing.Size(160, 21);
            this.cbEA.TabIndex = 24;
            this.cbEA.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rbEliminados
            // 
            this.rbEliminados.AutoSize = true;
            this.rbEliminados.Location = new System.Drawing.Point(568, 34);
            this.rbEliminados.Name = "rbEliminados";
            this.rbEliminados.Size = new System.Drawing.Size(75, 17);
            this.rbEliminados.TabIndex = 22;
            this.rbEliminados.Text = "Eliminados";
            this.rbEliminados.UseVisualStyleBackColor = true;
            this.rbEliminados.Click += new System.EventHandler(this.rbEliminados_Click);
            // 
            // rbNoEliminados
            // 
            this.rbNoEliminados.AutoSize = true;
            this.rbNoEliminados.Checked = true;
            this.rbNoEliminados.Location = new System.Drawing.Point(568, 66);
            this.rbNoEliminados.Name = "rbNoEliminados";
            this.rbNoEliminados.Size = new System.Drawing.Size(92, 17);
            this.rbNoEliminados.TabIndex = 23;
            this.rbNoEliminados.TabStop = true;
            this.rbNoEliminados.Text = "No Eliminados";
            this.rbNoEliminados.UseVisualStyleBackColor = true;
            this.rbNoEliminados.CheckedChanged += new System.EventHandler(this.rbNoEliminados_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(72, 79);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(124, 20);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(72, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(124, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(9, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::MySleepy.Properties.Resources.prestamos;
            this.btnLimpiar.Location = new System.Drawing.Point(808, 34);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(61, 58);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtCIFNIF
            // 
            this.txtCIFNIF.Enabled = false;
            this.txtCIFNIF.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCIFNIF.Location = new System.Drawing.Point(362, 79);
            this.txtCIFNIF.Name = "txtCIFNIF";
            this.txtCIFNIF.Size = new System.Drawing.Size(160, 20);
            this.txtCIFNIF.TabIndex = 3;
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Location = new System.Drawing.Point(299, 82);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(48, 13);
            this.lblPoblacion.TabIndex = 8;
            this.lblPoblacion.Text = "CIF/NIF:";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::MySleepy.Properties.Resources.Door_converted;
            this.btnSalir.Location = new System.Drawing.Point(928, 512);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(62, 54);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::MySleepy.Properties.Resources.papelera_de_reciclaje;
            this.btnBorrar.Location = new System.Drawing.Point(237, 168);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(61, 58);
            this.btnBorrar.TabIndex = 27;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::MySleepy.Properties.Resources.adwords_editor_128;
            this.btnModificar.Location = new System.Drawing.Point(142, 168);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(61, 58);
            this.btnModificar.TabIndex = 26;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Image = global::MySleepy.Properties.Resources.mas;
            this.btnAñadir.Location = new System.Drawing.Point(49, 168);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(61, 58);
            this.btnAñadir.TabIndex = 25;
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Image = global::MySleepy.Properties.Resources.restaurar;
            this.btnRestaurar.Location = new System.Drawing.Point(332, 168);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(61, 58);
            this.btnRestaurar.TabIndex = 30;
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProveedores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPROVEEDOR,
            this.cif,
            this.Nombre,
            this.Direccion,
            this.Telefono});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProveedores.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProveedores.GridColor = System.Drawing.Color.LightSalmon;
            this.dgvProveedores.Location = new System.Drawing.Point(37, 243);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(910, 252);
            this.dgvProveedores.TabIndex = 31;
            // 
            // IDPROVEEDOR
            // 
            this.IDPROVEEDOR.HeaderText = "IdProveedor";
            this.IDPROVEEDOR.Name = "IDPROVEEDOR";
            this.IDPROVEEDOR.ReadOnly = true;
            this.IDPROVEEDOR.Visible = false;
            // 
            // cif
            // 
            this.cif.HeaderText = "CIF/NIF";
            this.cif.Name = "cif";
            this.cif.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 100.6677F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Direccion
            // 
            this.Direccion.FillWeight = 95.77672F;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Telefono
            // 
            this.Telefono.FillWeight = 93.28328F;
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 578);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Name = "Proveedor";
            this.Text = "Proveedores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Proveedor_FormClosed);
            this.Load += new System.EventHandler(this.Proveedores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtCIFNIF;
        private System.Windows.Forms.Label lblPoblacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.RadioButton rbEliminados;
        private System.Windows.Forms.RadioButton rbNoEliminados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEA;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}
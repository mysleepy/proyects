﻿namespace MySleepy
{
    partial class ClientesForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesForm));
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.IDCLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poblacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.ckbBorrar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.txtCM = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(72, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(124, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCLIENTE,
            this.dni,
            this.Nombre,
            this.Apellido1,
            this.Apellido2,
            this.Telefono,
            this.Direccion,
            this.Poblacion,
            this.Email});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.GridColor = System.Drawing.Color.LightSalmon;
            this.dgvClientes.Location = new System.Drawing.Point(12, 225);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(968, 252);
            this.dgvClientes.TabIndex = 4;
            // 
            // IDCLIENTE
            // 
            this.IDCLIENTE.HeaderText = "IdCliente";
            this.IDCLIENTE.Name = "IDCLIENTE";
            this.IDCLIENTE.ReadOnly = true;
            this.IDCLIENTE.Visible = false;
            // 
            // dni
            // 
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 100.6677F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Apellido1
            // 
            this.Apellido1.FillWeight = 107.8276F;
            this.Apellido1.HeaderText = "1ºApellido";
            this.Apellido1.Name = "Apellido1";
            this.Apellido1.ReadOnly = true;
            this.Apellido1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Apellido2
            // 
            this.Apellido2.HeaderText = "2ºApellido";
            this.Apellido2.Name = "Apellido2";
            this.Apellido2.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.FillWeight = 93.28328F;
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Direccion
            // 
            this.Direccion.FillWeight = 95.77672F;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Poblacion
            // 
            this.Poblacion.FillWeight = 118.4385F;
            this.Poblacion.HeaderText = "Poblacion";
            this.Poblacion.Name = "Poblacion";
            this.Poblacion.ReadOnly = true;
            this.Poblacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Email
            // 
            this.Email.FillWeight = 112.94F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Location = new System.Drawing.Point(9, 78);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(57, 13);
            this.lblPoblacion.TabIndex = 8;
            this.lblPoblacion.Text = "Poblacion:";
            // 
            // ckbBorrar
            // 
            this.ckbBorrar.AutoSize = true;
            this.ckbBorrar.Location = new System.Drawing.Point(634, 34);
            this.ckbBorrar.Name = "ckbBorrar";
            this.ckbBorrar.Size = new System.Drawing.Size(68, 17);
            this.ckbBorrar.TabIndex = 15;
            this.ckbBorrar.Text = "Borrados";
            this.ckbBorrar.UseVisualStyleBackColor = true;
            this.ckbBorrar.CheckedChanged += new System.EventHandler(this.ckbBorrar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Comunidad Autonoma:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Provincia:";
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoblacion.Location = new System.Drawing.Point(72, 71);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(124, 20);
            this.txtPoblacion.TabIndex = 3;
            this.txtPoblacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoblacion_KeyPress);
            this.txtPoblacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPoblacion_KeyUp);
            // 
            // txtCM
            // 
            this.txtCM.Location = new System.Drawing.Point(634, 71);
            this.txtCM.Name = "txtCM";
            this.txtCM.Size = new System.Drawing.Size(125, 20);
            this.txtCM.TabIndex = 5;
            this.txtCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCM_KeyPress);
            this.txtCM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCM_KeyUp);
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(321, 71);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(134, 20);
            this.txtProvincia.TabIndex = 4;
            this.txtProvincia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProvincia_KeyPress);
            this.txtProvincia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProvincia_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "1ºApellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(321, 38);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(134, 20);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            this.txtApellido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtApellido_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ckbBorrar);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtProvincia);
            this.groupBox1.Controls.Add(this.txtPoblacion);
            this.groupBox1.Controls.Add(this.txtCM);
            this.groupBox1.Controls.Add(this.lblPoblacion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 123);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::MySleepy.Properties.Resources.prestamos;
            this.btnLimpiar.Location = new System.Drawing.Point(808, 34);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(71, 57);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::MySleepy.Properties.Resources.Door_converted;
            this.btnSalir.Location = new System.Drawing.Point(918, 500);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(62, 54);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::MySleepy.Properties.Resources.papelera_de_reciclaje;
            this.btnBorrar.Location = new System.Drawing.Point(196, 160);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(47, 43);
            this.btnBorrar.TabIndex = 13;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::MySleepy.Properties.Resources.adwords_editor_128;
            this.btnModificar.Location = new System.Drawing.Point(123, 160);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(45, 43);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Image = global::MySleepy.Properties.Resources.mas;
            this.btnAñadir.Location = new System.Drawing.Point(50, 160);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(45, 43);
            this.btnAñadir.TabIndex = 11;
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // ClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.dgvClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientesForm";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.ClientesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblPoblacion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox ckbBorrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.TextBox txtCM;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poblacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}


﻿namespace MySleepy
{
    partial class PedidosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPNoEliminado = new System.Windows.Forms.RadioButton();
            this.rbPEliminado = new System.Windows.Forms.RadioButton();
            this.rbNoPagados = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rbPagados = new System.Windows.Forms.RadioButton();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dgvPedidosRealizados = new System.Windows.Forms.DataGridView();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnBorrarPedido = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRealizados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbPNoEliminado);
            this.groupBox1.Controls.Add(this.rbPEliminado);
            this.groupBox1.Controls.Add(this.rbNoPagados);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.rbPagados);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.lblReferencia);
            this.groupBox1.Controls.Add(this.txtReferencia);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 162);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // rbPNoEliminado
            // 
            this.rbPNoEliminado.AutoSize = true;
            this.rbPNoEliminado.Checked = true;
            this.rbPNoEliminado.Location = new System.Drawing.Point(466, 125);
            this.rbPNoEliminado.Name = "rbPNoEliminado";
            this.rbPNoEliminado.Size = new System.Drawing.Size(92, 17);
            this.rbPNoEliminado.TabIndex = 53;
            this.rbPNoEliminado.TabStop = true;
            this.rbPNoEliminado.Text = "No Eliminados";
            this.rbPNoEliminado.UseVisualStyleBackColor = true;
            this.rbPNoEliminado.CheckedChanged += new System.EventHandler(this.rbPNoEliminado_CheckedChanged);
            this.rbPNoEliminado.Click += new System.EventHandler(this.rbPNoEliminado_Click);
            // 
            // rbPEliminado
            // 
            this.rbPEliminado.AutoSize = true;
            this.rbPEliminado.Location = new System.Drawing.Point(466, 81);
            this.rbPEliminado.Name = "rbPEliminado";
            this.rbPEliminado.Size = new System.Drawing.Size(75, 17);
            this.rbPEliminado.TabIndex = 52;
            this.rbPEliminado.TabStop = true;
            this.rbPEliminado.Text = "Eliminados";
            this.rbPEliminado.UseVisualStyleBackColor = true;
            this.rbPEliminado.CheckedChanged += new System.EventHandler(this.rbPEliminado_CheckedChanged);
            this.rbPEliminado.Click += new System.EventHandler(this.rbPEliminado_Click);
            // 
            // rbNoPagados
            // 
            this.rbNoPagados.AutoSize = true;
            this.rbNoPagados.Checked = true;
            this.rbNoPagados.Location = new System.Drawing.Point(331, 125);
            this.rbNoPagados.Name = "rbNoPagados";
            this.rbNoPagados.Size = new System.Drawing.Size(84, 17);
            this.rbNoPagados.TabIndex = 51;
            this.rbNoPagados.TabStop = true;
            this.rbNoPagados.Text = "No Pagados";
            this.rbNoPagados.UseVisualStyleBackColor = true;
            this.rbNoPagados.CheckedChanged += new System.EventHandler(this.rbNoEliminados_CheckedChanged);
            this.rbNoPagados.Click += new System.EventHandler(this.rbNoEliminados_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(376, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(239, 20);
            this.dateTimePicker1.TabIndex = 44;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rbPagados
            // 
            this.rbPagados.AutoSize = true;
            this.rbPagados.Location = new System.Drawing.Point(331, 81);
            this.rbPagados.Name = "rbPagados";
            this.rbPagados.Size = new System.Drawing.Size(67, 17);
            this.rbPagados.TabIndex = 50;
            this.rbPagados.TabStop = true;
            this.rbPagados.Text = "Pagados";
            this.rbPagados.UseVisualStyleBackColor = true;
            this.rbPagados.CheckedChanged += new System.EventHandler(this.rbEliminados_CheckedChanged);
            this.rbPagados.Click += new System.EventHandler(this.rbEliminados_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(25, 114);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 34;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(25, 31);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(58, 13);
            this.lblReferencia.TabIndex = 22;
            this.lblReferencia.Text = "Nº Pedido:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(93, 28);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(153, 20);
            this.txtReferencia.TabIndex = 23;
            this.txtReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferencia_KeyPress);
            this.txtReferencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReferencia_KeyUp);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(25, 72);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(42, 13);
            this.lblNombre.TabIndex = 30;
            this.lblNombre.Text = "Cliente:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(91, 111);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(153, 20);
            this.txtPrecio.TabIndex = 35;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::MySleepy.Properties.Resources.prestamos;
            this.btnLimpiar.Location = new System.Drawing.Point(587, 69);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(61, 58);
            this.btnLimpiar.TabIndex = 42;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(93, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(153, 20);
            this.txtNombre.TabIndex = 31;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::MySleepy.Properties.Resources.Door_converted;
            this.btnSalir.Location = new System.Drawing.Point(658, 475);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(62, 54);
            this.btnSalir.TabIndex = 52;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::MySleepy.Properties.Resources.Simbolo_del_dinero;
            this.btnBorrar.Location = new System.Drawing.Point(191, 189);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(61, 58);
            this.btnBorrar.TabIndex = 51;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // dgvPedidosRealizados
            // 
            this.dgvPedidosRealizados.AllowUserToAddRows = false;
            this.dgvPedidosRealizados.AllowUserToDeleteRows = false;
            this.dgvPedidosRealizados.AllowUserToResizeColumns = false;
            this.dgvPedidosRealizados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPedidosRealizados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidosRealizados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidosRealizados.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvPedidosRealizados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidosRealizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosRealizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origen,
            this.Nombre,
            this.Destino,
            this.Texto,
            this.Telefono});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Black", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosRealizados.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPedidosRealizados.GridColor = System.Drawing.Color.LightSalmon;
            this.dgvPedidosRealizados.Location = new System.Drawing.Point(20, 266);
            this.dgvPedidosRealizados.Name = "dgvPedidosRealizados";
            this.dgvPedidosRealizados.RowHeadersVisible = false;
            this.dgvPedidosRealizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosRealizados.Size = new System.Drawing.Size(671, 194);
            this.dgvPedidosRealizados.TabIndex = 50;
            // 
            // Origen
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Origen.DefaultCellStyle = dataGridViewCellStyle2;
            this.Origen.FillWeight = 71.06599F;
            this.Origen.HeaderText = "NºPedido";
            this.Origen.Name = "Origen";
            // 
            // Nombre
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nombre.HeaderText = "Fecha";
            this.Nombre.Name = "Nombre";
            // 
            // Destino
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Destino.DefaultCellStyle = dataGridViewCellStyle4;
            this.Destino.FillWeight = 58.28161F;
            this.Destino.HeaderText = "Cliente";
            this.Destino.Name = "Destino";
            // 
            // Texto
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Texto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Texto.FillWeight = 61.92574F;
            this.Texto.HeaderText = "Importe";
            this.Texto.Name = "Texto";
            // 
            // Telefono
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Telefono.DefaultCellStyle = dataGridViewCellStyle6;
            this.Telefono.FillWeight = 94.99262F;
            this.Telefono.HeaderText = "Pagado";
            this.Telefono.Name = "Telefono";
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::MySleepy.Properties.Resources.adwords_editor_128;
            this.btnModificar.Location = new System.Drawing.Point(113, 189);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(61, 58);
            this.btnModificar.TabIndex = 49;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Image = global::MySleepy.Properties.Resources.mas;
            this.btnAñadir.Location = new System.Drawing.Point(42, 189);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(61, 58);
            this.btnAñadir.TabIndex = 48;
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // btnBorrarPedido
            // 
            this.btnBorrarPedido.Image = global::MySleepy.Properties.Resources.papelera_de_reciclaje;
            this.btnBorrarPedido.Location = new System.Drawing.Point(269, 189);
            this.btnBorrarPedido.Name = "btnBorrarPedido";
            this.btnBorrarPedido.Size = new System.Drawing.Size(61, 58);
            this.btnBorrarPedido.TabIndex = 54;
            this.btnBorrarPedido.UseVisualStyleBackColor = true;
            this.btnBorrarPedido.Click += new System.EventHandler(this.btnBorrarPedido_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Fecha:";
            // 
            // PedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 541);
            this.Controls.Add(this.btnBorrarPedido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dgvPedidosRealizados);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAñadir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PedidosForm";
            this.Text = "PedidosForm";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRealizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNoPagados;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rbPagados;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dgvPedidosRealizados;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.RadioButton rbPNoEliminado;
        private System.Windows.Forms.RadioButton rbPEliminado;
        private System.Windows.Forms.Button btnBorrarPedido;
        private System.Windows.Forms.Label label1;



    }
}
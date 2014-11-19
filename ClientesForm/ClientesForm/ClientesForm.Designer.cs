namespace ClientesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvTransmisiones = new System.Windows.Forms.DataGridView();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poblacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransmisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(103, 26);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(100, 20);
            this.txtReferencia.TabIndex = 0;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(35, 29);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 1;
            this.lblReferencia.Text = "Referencia:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(332, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(384, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // dgvTransmisiones
            // 
            this.dgvTransmisiones.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTransmisiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransmisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransmisiones.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvTransmisiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransmisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransmisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origen,
            this.Destino,
            this.Texto,
            this.Telefono,
            this.Direccion,
            this.Poblacion,
            this.Email});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Black", 9.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransmisiones.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransmisiones.GridColor = System.Drawing.Color.LightSalmon;
            this.dgvTransmisiones.Location = new System.Drawing.Point(38, 97);
            this.dgvTransmisiones.Name = "dgvTransmisiones";
            this.dgvTransmisiones.RowHeadersVisible = false;
            this.dgvTransmisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransmisiones.Size = new System.Drawing.Size(764, 219);
            this.dgvTransmisiones.TabIndex = 4;
            this.dgvTransmisiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransmisiones_CellContentClick);
            // 
            // Origen
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Origen.DefaultCellStyle = dataGridViewCellStyle2;
            this.Origen.FillWeight = 71.06599F;
            this.Origen.HeaderText = "Ref.Cliente";
            this.Origen.Name = "Origen";
            // 
            // Destino
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Destino.DefaultCellStyle = dataGridViewCellStyle3;
            this.Destino.FillWeight = 58.28161F;
            this.Destino.HeaderText = "Nombre";
            this.Destino.Name = "Destino";
            // 
            // Texto
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Texto.DefaultCellStyle = dataGridViewCellStyle4;
            this.Texto.FillWeight = 61.92574F;
            this.Texto.HeaderText = "Apellido";
            this.Texto.Name = "Texto";
            // 
            // Telefono
            // 
            this.Telefono.FillWeight = 94.99262F;
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Direccion
            // 
            this.Direccion.FillWeight = 96.87238F;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            // 
            // Poblacion
            // 
            this.Poblacion.FillWeight = 120.6087F;
            this.Poblacion.HeaderText = "Poblacion";
            this.Poblacion.Name = "Poblacion";
            // 
            // Email
            // 
            this.Email.FillWeight = 196.2529F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Location = new System.Drawing.Point(608, 29);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(57, 13);
            this.lblPoblacion.TabIndex = 8;
            this.lblPoblacion.Text = "Poblacion:";
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoblacion.Location = new System.Drawing.Point(671, 26);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacion.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(695, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Limpiar Filtros";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(762, 371);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(611, 371);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(465, 371);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // ClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 437);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPoblacion);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.dgvTransmisiones);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.txtReferencia);
            this.Name = "ClientesForm";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransmisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvTransmisiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poblacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Label lblPoblacion;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}


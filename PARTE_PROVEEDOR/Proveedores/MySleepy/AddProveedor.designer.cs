namespace MySleepy
{
    partial class AddProveedor
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCP = new System.Windows.Forms.ComboBox();
            this.cbCAutonoma = new System.Windows.Forms.ComboBox();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.cbPoblacion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCIF = new System.Windows.Forms.TextBox();
            this.lCIF = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lDNI = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEA = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::MySleepy.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(354, 332);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(53, 55);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::MySleepy.Properties.Resources.guardar;
            this.btnGuardar.Location = new System.Drawing.Point(226, 332);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(49, 55);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCP);
            this.groupBox2.Controls.Add(this.cbCAutonoma);
            this.groupBox2.Controls.Add(this.cbProvincia);
            this.groupBox2.Controls.Add(this.cbPoblacion);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 146);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dirección";
            // 
            // cbCP
            // 
            this.cbCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCP.FormattingEnabled = true;
            this.cbCP.Location = new System.Drawing.Point(435, 94);
            this.cbCP.Name = "cbCP";
            this.cbCP.Size = new System.Drawing.Size(147, 21);
            this.cbCP.TabIndex = 10;
            this.cbCP.SelectedIndexChanged += new System.EventHandler(this.cbCP_SelectedIndexChanged);
            // 
            // cbCAutonoma
            // 
            this.cbCAutonoma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCAutonoma.FormattingEnabled = true;
            this.cbCAutonoma.Location = new System.Drawing.Point(140, 27);
            this.cbCAutonoma.Name = "cbCAutonoma";
            this.cbCAutonoma.Size = new System.Drawing.Size(147, 21);
            this.cbCAutonoma.TabIndex = 7;
            this.cbCAutonoma.SelectedIndexChanged += new System.EventHandler(this.cbCAutonoma_SelectedIndexChanged);
            // 
            // cbProvincia
            // 
            this.cbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(140, 55);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(147, 21);
            this.cbProvincia.TabIndex = 8;
            this.cbProvincia.Tag = "";
            this.cbProvincia.SelectedIndexChanged += new System.EventHandler(this.cbProvincia_SelectedIndexChanged);
            // 
            // cbPoblacion
            // 
            this.cbPoblacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPoblacion.FormattingEnabled = true;
            this.cbPoblacion.Location = new System.Drawing.Point(435, 54);
            this.cbPoblacion.Name = "cbPoblacion";
            this.cbPoblacion.Size = new System.Drawing.Size(147, 21);
            this.cbPoblacion.TabIndex = 9;
            this.cbPoblacion.SelectedIndexChanged += new System.EventHandler(this.cbPoblacion_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Comunidad Autónoma:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(140, 95);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(177, 20);
            this.txtDireccion.TabIndex = 11;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Poblacion:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Provincia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Avenida/Calle:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "C.P:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCIF);
            this.groupBox1.Controls.Add(this.lCIF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lDNI);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(56, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 139);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Personales";
            // 
            // txtCIF
            // 
            this.txtCIF.Location = new System.Drawing.Point(97, 61);
            this.txtCIF.Name = "txtCIF";
            this.txtCIF.Size = new System.Drawing.Size(124, 20);
            this.txtCIF.TabIndex = 1;
            this.txtCIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCIF_KeyPress);
            // 
            // lCIF
            // 
            this.lCIF.AutoSize = true;
            this.lCIF.Location = new System.Drawing.Point(61, 64);
            this.lCIF.Name = "lCIF";
            this.lCIF.Size = new System.Drawing.Size(26, 13);
            this.lCIF.TabIndex = 22;
            this.lCIF.Text = "CIF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(97, 96);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(124, 20);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lDNI
            // 
            this.lDNI.AutoSize = true;
            this.lDNI.Location = new System.Drawing.Point(291, 64);
            this.lDNI.Name = "lDNI";
            this.lDNI.Size = new System.Drawing.Size(29, 13);
            this.lDNI.TabIndex = 14;
            this.lDNI.Text = "DNI:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(326, 96);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(124, 20);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(326, 61);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(124, 20);
            this.txtDNI.TabIndex = 3;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "EMPRESA/AUTONOMO:";
            // 
            // cbEA
            // 
            this.cbEA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEA.FormattingEnabled = true;
            this.cbEA.Items.AddRange(new object[] {
            "Empresa",
            "Autonomo"});
            this.cbEA.Location = new System.Drawing.Point(191, 24);
            this.cbEA.Name = "cbEA";
            this.cbEA.Size = new System.Drawing.Size(160, 21);
            this.cbEA.TabIndex = 25;
            this.cbEA.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AddProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 399);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddProveedor";
            this.Text = "AddProveedor";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbCP;
        private System.Windows.Forms.ComboBox cbCAutonoma;
        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.ComboBox cbPoblacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCIF;
        private System.Windows.Forms.Label lCIF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lDNI;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEA;

    }
}
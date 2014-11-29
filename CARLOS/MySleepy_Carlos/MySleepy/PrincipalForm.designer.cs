namespace MySleepy
{
    partial class PrincipalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.historialToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // lblTipoUsuario
            // 
            resources.ApplyResources(this.lblTipoUsuario, "lblTipoUsuario");
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            // 
            // sistemaToolStripMenuItem
            // 
            resources.ApplyResources(this.sistemaToolStripMenuItem, "sistemaToolStripMenuItem");
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Image = global::MySleepy.Properties.Resources.mantenimiento;
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            // 
            // usuariosToolStripMenuItem
            // 
            resources.ApplyResources(this.usuariosToolStripMenuItem, "usuariosToolStripMenuItem");
            this.usuariosToolStripMenuItem.Image = global::MySleepy.Properties.Resources.socios;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            resources.ApplyResources(this.clientesToolStripMenuItem, "clientesToolStripMenuItem");
            this.clientesToolStripMenuItem.Image = global::MySleepy.Properties.Resources.clientes;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            resources.ApplyResources(this.articulosToolStripMenuItem, "articulosToolStripMenuItem");
            this.articulosToolStripMenuItem.Image = global::MySleepy.Properties.Resources.materias;
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            resources.ApplyResources(this.cerrarSesiónToolStripMenuItem, "cerrarSesiónToolStripMenuItem");
            this.cerrarSesiónToolStripMenuItem.Image = global::MySleepy.Properties.Resources.cerrarSesion;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Image = global::MySleepy.Properties.Resources.Door_converted;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            resources.ApplyResources(this.pedidosToolStripMenuItem, "pedidosToolStripMenuItem");
            this.pedidosToolStripMenuItem.Image = global::MySleepy.Properties.Resources.editoriales;
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            resources.ApplyResources(this.historialToolStripMenuItem, "historialToolStripMenuItem");
            this.historialToolStripMenuItem.Image = global::MySleepy.Properties.Resources.historial;
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            // 
            // PrincipalForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTipoUsuario);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}


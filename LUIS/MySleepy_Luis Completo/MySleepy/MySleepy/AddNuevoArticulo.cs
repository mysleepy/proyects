using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySleepy
{
    public partial class AddNuevoArticulo : Form
    {
        ConnectDB conexion;
        public AddNuevoArticulo(ConnectDB c)
        {
            InitializeComponent();
            dgvArticulos.ClearSelection();
            this.conexion = c;
            
            cargarDGV();
        }

        public void cargarDGV(){
            ejecutarConsulta();
        }

        private void ejecutarConsulta()
        {
            String sentencia = "SELECT NOMBRE,COMPOSICION,PRECIO FROM ARTICULOS";
            DataSet resultado=conexion.getData(sentencia,"tArticulos");
            dgvArticulos.DataSource = resultado;

        }

        private void AddArticulo_Load(object sender, EventArgs e)
        {
            dgvArticulos.ClearSelection();
            dgvArticulos.Update();
        }
    }
}

using ProgSistemas.BA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgSistemas.FE
{
    public partial class Form1 : Form
    {
        Productos Productos;

        private frmInventario frmInventario;

        List<Producto> ListaProductos;
        public Form1()
        {
            InitializeComponent();            
            Productos = new Productos();            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventario = new frmInventario();
            frmInventario.Show();
            frmInventario.Activate();
        }
    }
}

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
    public partial class frmAgregarProd : Form
    {
        frmInventario FrmInventario;
        public frmAgregarProd(frmInventario frmInventario)
        {
            InitializeComponent();
            FrmInventario = frmInventario;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Precio = Convert.ToDecimal(txtPrecio.Text);
            producto.UnidadMedida = txtUMedida.Text;
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

            FrmInventario.GuardarProducto(producto);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

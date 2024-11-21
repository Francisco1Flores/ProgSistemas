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
    public partial class frmInventario : Form
    {
        private Productos Productos;

        frmAgregarProd frmAgregarProd;
        public frmInventario()
        {
            Productos = new Productos();
            InitializeComponent();
            dgvListaProd.DataSource = Productos.LeerTodos();            
            txtCodigo.Enabled = false;                        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarProd = new frmAgregarProd(this);
            frmAgregarProd.Show();
            frmAgregarProd.Activate();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Precio = Convert.ToDecimal(txtPrecio.Text);
            producto.UnidadMedida = txtUMedida.Text;
            producto.Cantidad = Convert.ToInt32(txtCantidad.Text);

            Productos.Actualizar(producto.Codigo, producto);
            dgvListaProd.DataSource=Productos.LeerTodos();
            dgvListaProd.Refresh();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Productos.Eliminar(txtCodigo.Text);
            dgvListaProd.DataSource = Productos.LeerTodos();
            dgvListaProd.Refresh();
        }

        private void dgvListaProd_SelectionChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = dgvListaProd.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvListaProd.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dgvListaProd.CurrentRow.Cells[2].Value.ToString();
            txtUMedida.Text = dgvListaProd.CurrentRow.Cells[3].Value.ToString();
            txtCantidad.Text = dgvListaProd.CurrentRow.Cells[4].Value.ToString();
        }

        public void GuardarProducto(Producto producto)
        {
            Productos.Insertar(producto);
            dgvListaProd.DataSource= Productos.LeerTodos();
            dgvListaProd.Refresh();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.BancoSangre
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAgregar = new FormAgregar();
            formAgregar.MdiParent = this;
            formAgregar.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCompras = new FormCompras();
            formCompras.MdiParent = this;
            formCompras.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formVentas = new FormVentas();
            formVentas.MdiParent = this;
            formVentas.Show();
        }

        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRclientes = new FormRClientes();
            formRclientes.MdiParent = this;
            formRclientes.Show();
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRventas = new FormRVentas();
            formRventas.MdiParent = this;
            formRventas.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formInventarios = new FormInventarios();
            formInventarios.MdiParent = this;
            formInventarios.Show();
        }

        private void eliminarDonantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEliminar = new FormEliminar();
            formEliminar.MdiParent = this;
            formEliminar.Show();
        }
    }
}

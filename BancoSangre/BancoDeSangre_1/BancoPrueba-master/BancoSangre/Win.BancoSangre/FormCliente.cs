using BL.BancoSangre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.BancoSangre
{
    public partial class FormCliente : Form
    {
        ClientesBL _clientesBL;
       
        public FormCliente()
        {
            InitializeComponent();

            _clientesBL = new ClientesBL();
            listadeClientesBindingSource.DataSource = _clientesBL.ObtenerClientes();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listadeClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listadeClientesBindingSource.EndEdit();
            var cliente = (Cliente)listadeClientesBindingSource.Current;
            var res = _clientesBL.GuardarCliente(cliente);
            if (res.Exitoso==true)
            {
                listadeClientesBindingSource.ResetBindings(false);

                DeshablilitarHabilitarBotones(true);
                MessageBox.Show("Guardado");
                
            }
            else
            {
                MessageBox.Show(res.Mensaje);
            }
        }

       

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientesBL.AgregarClientes();
            listadeClientesBindingSource.MoveLast();
           
            DeshablilitarHabilitarBotones(false);
        }

        private void DeshablilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
                {
                   
                        var id = Convert.ToInt32(idTextBox.Text);
                        Eliminar(id);
                }
                


        }

        private void Eliminar(int id)
        {
            

            var res = _clientesBL.EliminarCliente(id);
            if (res == true)
            {
                listadeClientesBindingSource.ResetBindings(false);
            }
            else
                MessageBox.Show("Error en eliminar Cliente");
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _clientesBL.CancelarCambios();
            DeshablilitarHabilitarBotones(true);
        }
    }
}

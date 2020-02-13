using BL.BancoSangre;
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
    public partial class FormLogin : Form
    {
        SeguridadBL _seguridad;

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario, password;
            usuario = textBox1.Text;
            password = textBox2.Text;

           var resultado= _seguridad.Autorizar(usuario, password);

            if (resultado)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o Contraseña que ingresó es incorrecto!");
            }
        }
    }
}

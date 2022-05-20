using PepitoSchoolApp.Applications.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolApp.Forms
{
    public partial class Form1 : Form
    {
        private IEstudianteService estudianteService;
        public Form1(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            InitializeComponent();
        }
        public bool Verificar()
        {
            if(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(txtCarnet.Text) || String.IsNullOrEmpty(txtTelefono.Text) ||
                String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtCorreo.Text))
            {
                return false;
            }
            return true;
        }
        private void brnEnviar_Click(object sender, EventArgs e)
        {

        }
    }
}

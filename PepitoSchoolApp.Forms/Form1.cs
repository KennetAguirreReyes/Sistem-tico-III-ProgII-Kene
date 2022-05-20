using PepitoSchoolApp.Applications.Interfaces;
using PepitoSchoolApp.Applications.Services;
using PepitoSchoolApp.Domain.Entities;
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
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellido.Text) || String.IsNullOrEmpty(txtCarnet.Text) || String.IsNullOrEmpty(txtTelefono.Text) ||
                String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtCorreo.Text))
            {
                return false;
            }
            return true;
        }
        private void brnEnviar_Click(object sender, EventArgs e)
        {
            if (Verificar())
            {
                Estudiante estudiante = new Estudiante()
                {
                    Nombres = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    Carnet = txtApellido.Text,
                    Phone = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematicas = (int)nudMatematica.Value,
                    Contabilidad = (int)nudContabilidad.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Estadistica = (int)nudEstadistica.Value,
                };
                estudianteService.Create(estudiante);
                LlenarDTGV();
                LimpiarTextBoxs();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos de información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Verificar())
            {
                Estudiante estudiante = new Estudiante()
                {
                    Nombres = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    Carnet = txtApellido.Text,
                    Phone = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematicas = (int)nudMatematica.Value,
                    Contabilidad = (int)nudContabilidad.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Estadistica = (int)nudEstadistica.Value,
                };
                estudianteService.Update(estudiante);
                LlenarDTGV();
                LimpiarTextBoxs();
                MessageBox.Show($"Se ha actualizado los datos del estudiante {estudiante.Nombres} con Id {estudiante.Id}");
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos de información", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dtgvEstudiante.CurrentCell.RowIndex;
            if (index >= 0)
            {
                Estudiante estudiante = estudianteService.GetAll()[index];
                estudianteService.Delete(estudiante);
                dtgvEstudiante.DataSource = null;
                dtgvEstudiante.DataSource = estudianteService.GetAll();
            }

        }

        public void LlenarDTGV()
        {
            dtgvEstudiante.DataSource = estudianteService.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarDTGV();
        }

        private void LimpiarTextBoxs()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCarnet.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            nudMatematica.Value = 0;
            nudContabilidad.Value = 0;
            nudProgramacion.Value = 0;
            nudEstadistica.Value = 0;
        }

        
    }
}

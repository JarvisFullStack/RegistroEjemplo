using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEjemplo.Entidades;
using RegistroEjemplo.BLL;

namespace RegistroEjemplo.UI.Registros
{
    public partial class RegistroPersonas : Form
    {
        public RegistroPersonas()
        {
            InitializeComponent();
        }

        private void RegistroPersonas_Load(object sender, EventArgs e)
        {

        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaId = Convert.ToInt32(IDnumericUpDown.Value);
            persona.Nombres = NombrestextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Telefono = TelefonomaskedTextBox.Text;
            persona.Direccion = DirecciontextBox.Text;

            return persona;
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            IDnumericUpDown.Value = 0;
            NombrestextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CedulamaskedTextBox.Clear();


        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            Persona persona = LlenaClase();
            bool paso = false;

            if(IDnumericUpDown.Value == 0) {
                paso = BLL.PersonasBLL.Guardar(persona);
            }
            else
            {
                paso = BLL.PersonasBLL.Modificar(LlenaClase());
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Guardar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDnumericUpDown.Value);
            Persona persona = BLL.PersonasBLL.Buscar(id);
            if(persona != null)
            {
                NombrestextBox.Text = persona.Nombres;
                DirecciontextBox.Text = persona.Direccion;
                TelefonomaskedTextBox.Text = persona.Telefono;
                CedulamaskedTextBox.Text = persona.Cedula;
            }
            else
            {
                MessageBox.Show("No se encontro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDnumericUpDown.Value);
            if (BLL.PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Se elimino correctamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

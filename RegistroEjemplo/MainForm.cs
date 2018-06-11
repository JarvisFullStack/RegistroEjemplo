using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEjemplo.UI;

namespace RegistroEjemplo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.RegistroPersonas registro = new UI.Registros.RegistroPersonas();
            registro.Show();
            
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.ConsultaPersonas consulta = new UI.Consultas.ConsultaPersonas();
            consulta.Show();
        }
    }
}

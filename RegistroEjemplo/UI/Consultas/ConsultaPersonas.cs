using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroEjemplo.Entidades;
namespace RegistroEjemplo.UI.Consultas

{
    public partial class ConsultaPersonas : Form
    {
        public ConsultaPersonas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Filtro inicializa en true.
            Expression<Func<Persona, bool>> filtro = x => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0: //ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.PersonaId == id;
                    break;
                case 1://Nombre
                    filtro = x => x.Nombres.Equals(CriteriotextBox.Text);
                    break;
                case 2://Cedula
                    filtro = x => x.Cedula.Equals(CriteriotextBox.Text);
                    break;
                case 3://Direccion
                    filtro = x => x.Direccion.Equals(CriteriotextBox.Text);
                    break;
                case 4: //Telefono
                    filtro = x => x.Telefono.Equals(CriteriotextBox.Text);
                    break;

            }
            ConsultadataGridView.DataSource = BLL.PersonasBLL.GetList(filtro);

        }
    }
}

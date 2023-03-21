using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormBuscarGrupoUsuario : Form
    {
        public FormBuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
                grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }
        private void buttonExcluirGrupoUsuario_Click(object sender, EventArgs e)
        {
            if (grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado para ser excluído");
                return;
            }

            if (MessageBox.Show("Deseja excluir esse registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            new GrupoUsuarioBLL().Excluir(id);
            grupoUsuarioBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluído com sucesso");
        }
        private void buttonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {
                using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
                {
                    frm.ShowDialog();
                }
                buttonBuscar_Click(null, null);
        }



        //não inseridos
        private void BuscarGrupoUsuario_Load(object sender, EventArgs e)
        {

        }
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario(id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);

        }

    }
}

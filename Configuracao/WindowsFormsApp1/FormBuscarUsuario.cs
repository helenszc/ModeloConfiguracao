﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Models;

namespace WindowsFormsApp1
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonExcluirUsuario_Click(object sender, EventArgs e)
        {
            if(usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não há registro selecionado para ser excluído");
                return;
            }

            if(MessageBox.Show("Deseja excluir esse registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            usuarioBindingSource.RemoveCurrent();

            MessageBox.Show("Registro excluído com sucesso");
        }

        private void buttonAdicionarUsuario_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null,null);
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)usuarioBindingSource.Current).Id;
            using (FormCadastroUsuario frm = new FormCadastroUsuario(id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }


        //não inserido
        private void buttonExcluirGrupoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void gruposUsuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }
    }
}

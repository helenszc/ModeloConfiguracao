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
    public partial class FormCadastroUsuario : Form
    {
        public int Id;
        public FormCadastroUsuario(int _id)
        {
            InitializeComponent();
            Id = _id;
        }


        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.EndEdit();
            usuarioBLL.Inserir((Usuario)usuarioBindingSource.Current);
            MessageBox.Show("Registro salvo com sucesso!");
            Close();
        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {
            usuarioBindingSource.AddNew();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

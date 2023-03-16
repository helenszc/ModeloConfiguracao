
using DAL;
using Models;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario)
        {
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();  
            usuarioDAL.Inserir(_usuario);

        }

        public void Alterar(Usuario _usuario)
        {
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }
        private void ValidarDados(Usuario _usuario)
        {
            if (_usuario.Senha.Length <= 3)
            {
                throw new Exception("A senha deve ter mais de 3 caracteres");
            }

            if(_usuario.Nome.Length <= 2)
            {
                throw new Exception("O nome deve ter mais de 2 caracteres");
            }
        }
    }
}

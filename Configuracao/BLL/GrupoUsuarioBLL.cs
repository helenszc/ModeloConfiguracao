using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
           new UsuarioBLL().ValidarPermissao(6);
            GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
            grupoUsuarioDAL.Inserir(_grupoUsuario);

            if(_grupoUsuario.NomeGrupo.Length < 5)
            {
                throw new Exception("O nome do grupo deve conter pelo menos 5 caracteres");
            }
            if(_grupoUsuario.NomeGrupo.Length > 20)
            {
                throw new Exception("O nome do grupo não deve ser tão grande(no maximo 20 caracteres)");
            }

        }

        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            new UsuarioBLL().ValidarPermissao(7);
            new GrupoUsuarioDAL().Alterar(_grupoUsuario);
        }

        public void Excluir(int _id)
        {
            new UsuarioBLL().ValidarPermissao(8);
            new GrupoUsuarioDAL().Excluir(_id);
        }

        public List<GrupoUsuario> BuscarTodos()
        {
            new UsuarioBLL().ValidarPermissao(5);
            return new GrupoUsuarioDAL().BuscarTodos();
        }

        public GrupoUsuario BuscarPorId(int _id)
        {
            new UsuarioBLL().ValidarPermissao(5);
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }

        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            new UsuarioBLL().ValidarPermissao(5);
            return new GrupoUsuarioDAL().BuscarPorNomeGrupo(_nomeGrupo);
        }

        public void AdicionarPermissao(int _idGrupoUsuario, int _idPermissao)
        {
            new UsuarioBLL().ValidarPermissao(9);
            if (!new GrupoUsuarioDAL().GrupoUsuarioPertenceAPermissao(_idGrupoUsuario, _idPermissao))
                new GrupoUsuarioDAL().AdicionarPermissao(_idGrupoUsuario, _idPermissao);
        }

        public void RemoverPermissao(int _idGrupoUsuario, int _idPermissao)
        {
            new UsuarioBLL().ValidarPermissao(11);
            new GrupoUsuarioDAL().RemoverPermissao(_idGrupoUsuario, _idGrupoUsuario);
        }
    }
}

using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissaoBLL
    {
        public void Inserir(Permissao _permissao)
        {
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Inserir(_permissao);

            if(_permissao.Descricao.Length < 5)
            {
                throw new Exception("A descrição deve conter pelo menos caracteres");
            }
            if(_permissao.Descricao.Length > 50)
            {
                throw new Exception("A descrição não pode ser tão longa(no maximo 50 caracteres)");
            }

        }

        public void Alterar(Permissao _permissao)
        {

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);
        }

        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);
        }

        public List<Permissao> BuscarTodos()
        {
            return new PermissaoDAL().BuscarTodos();
        }

        public Permissao BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }

        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }
    }
}

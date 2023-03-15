using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermissaoDALcs
    {
        public void Inserir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Permissao(Descricao)
                                    VALUES(@Descricao)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricao", _permissao.Descricao);


                cmd.Connection = cn;
                cn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir uma permissao no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Permissao> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            throw new NotImplementedException();
        }

        public List<Permissao> BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }

        public void Alterar(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Permissao set Descricao = @Descricao WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Descricao", _permissao.Descricao);
                cmd.Parameters.AddWithValue("@Id", _permissao.Id);

                cmd.Connection = cn;
                cn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar alterar uma permissao no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"DELETE FROM Permissao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir uma permissao do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

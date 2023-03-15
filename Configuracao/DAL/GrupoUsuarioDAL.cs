using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
            public void Inserir(GrupoUsuario _grupoUsuario)
            {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO GrupoUsuario (NomeGrupo)
                                    VALUES(@NomeGrupo)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario.NomeGrupo);

                cmd.Connection = cn;
                cn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um grupo usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

            public List<GrupoUsuario> BuscarTodos()
            {
                throw new NotImplementedException();
            }

            public List<GrupoUsuario> BuscarPorNomeGrupoUsuario(string _nomeGrupoUsuario)
            {
                throw new NotImplementedException();
            }

            public List<GrupoUsuario> BuscarPorId(int _id)
            {
                throw new NotImplementedException();
            }

            public void Alterar(GrupoUsuario _grupoUsuario)
            {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE  GrupoUsuario set NomeGrupo = @NomeGrupo WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario.NomeGrupo);
                cmd.Parameters.AddWithValue("@Id", _grupoUsuario.Id);

                cmd.Connection = cn;
                cn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar alterar um usuário no banco de dados", ex);
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
                cmd.CommandText = @"DELETE FROM GrupoUsuario WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir um grupo de usuario do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

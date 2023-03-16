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
                List<GrupoUsuario> grupoUsuarios = new List<GrupoUsuario>();
                GrupoUsuario grupoUsuario;

                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT Id,NomeGrupo FROM GrupoUsuario";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            grupoUsuario = new GrupoUsuario();
                            grupoUsuario.Id = Convert.ToInt32(rd["Id"]);
                            grupoUsuario.NomeGrupo = rd["NomeGrupo"].ToString();

                            grupoUsuarios.Add(grupoUsuario);

                        }
                    }
                    return grupoUsuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar buscar todos os grupos de usuários do banco de dados", ex);
                }
                finally
                {
                    cn.Close();
                }
        }

            public GrupoUsuario BuscarPorNomeGrupo(string _nomeGrupo)
            {
            GrupoUsuario grupoUsuario = new GrupoUsuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,NomeGrupo FROM GrupoUsuario WHERE NomeGrupo = @NomeGrupo";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeGrupo", _nomeGrupo);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        grupoUsuario.Id = Convert.ToInt32(rd["Id"]);
                        grupoUsuario.NomeGrupo = rd["NomeGrupo"].ToString();

                    }
                }
                return grupoUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario por nome do grupo do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
     }

            public GrupoUsuario BuscarPorId(int _id)
            {
            GrupoUsuario grupoUsuario = new GrupoUsuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,NomeGrupo FROM Usuario WHERE Id=@Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        grupoUsuario.Id = Convert.ToInt32(rd["Id"]);
                        grupoUsuario.NomeGrupo = rd["NomeGrupo"].ToString();
                    }
                }
                return grupoUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o grupo de usuario por id do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
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

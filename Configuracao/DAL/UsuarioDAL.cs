using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, Email, CPF, Ativo, Senha)
                                    VALUES(@Nome, @NomeUsuario, @Email, @CPF, @Ativo, @Senha)";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);

                cmd.Connection = cn;
                cn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }

        }

        public List<Usuario> BuscarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();

                        usuarios.Add(usuario);

                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos od usuários do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE NomeUsuario = @NomeUsuario";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();



                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario por nome do usuario do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public Usuario BuscarPorId(int _id)
        {

            Usuario usuario = new Usuario();

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nome, NomeUsuario, Email, CPF, Ativo, Senha FROM Usuario WHERE Id=@Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario por id do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Usuario> BuscarPorNome(string _nome)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Nome, NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario WHERE Nome LIKE @Nome ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", "%" + _nome + "%");
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["Id"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();

                        usuarios.Add(usuario);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario por nome do banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar(Usuario _usuario)
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
                try
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = @"UPDATE  Usuario set Nome = @Nome, NomeUsuario = @NomeUsuario, Email = @Email, CPF = @CPF, Ativo =@Ativo, Senha = @Senha WHERE Id = @Id";

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                    cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                    cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                    cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                    cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                    cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                    cmd.Parameters.AddWithValue("@Id", _usuario.Id);

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
                    cmd.CommandText = @"DELETE FROM Usuario WHERE Id = @Id";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", _id);

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception("Ocorreu um erro ao tentar excluir um usuario do banco de dados", ex);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }

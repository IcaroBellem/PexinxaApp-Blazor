using Microsoft.Data.SqlClient;
using Pexinxa.Models;
using System.Security.Cryptography;
using System.Text;

namespace Pexinxa.Repositories.ADO.SQLServer
{
    public class EmailDAO
    {
        private readonly string connectionString;

        public EmailDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        //Criptografia de Senha
        public static string CriptografarSenha(string Senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }

        }

        // Criar o método de validação do Login do Usuário.
        public bool check(Tb_Usuario usuario)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Usuario_Id FROM tb_Usuario WHERE Email = @Email and Senha = @Senha; ";

                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = usuario.Email;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = EmailDAO.CriptografarSenha(usuario.Senha);


                    // Executa o comando da SQL: "SELECT". 
                    SqlDataReader dr = command.ExecuteReader();

                    // Se encontrado o usuário, result é verdadeiro (result = true;),
                    // caso contrário, result se mantém como falso (result = false;).
                    result = dr.Read();
                }
            }
            // retorna o valor de result (true ou false).
            return result;
        }


        /*
        public Tb_Usuario getTipo(Tb_Usuario usuario)
        {
            Tb_Usuario result = new Tb_Usuario();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Usuario_Id, Nivel FROM tb_Usuario WHERE Email = @Email AND Senha = @Senha";
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = usuario.Email;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = usuario.Senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result. = dr.Read();

                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id"];
                            result.TipoUsuario = dr["tipo"].ToString();

                            email.Email_Id = result.Id;
                            email.TipoUsuario = result.TipoUsuario;
                        } // encerra if.
                    } // encerra using SqlDataReader.

                } // encerra using SqlCommand.

                //...executar códigos dentro da sessão durante o login do usuário efetuado com sucesso.

            } // encerra using SqlConnection.

            return result;
        }
        */
    }
}

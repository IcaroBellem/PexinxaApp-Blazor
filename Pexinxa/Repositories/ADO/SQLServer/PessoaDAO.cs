using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pexinxa.Models;
using System.Security.Cryptography;
using System.Text;



namespace Pexinxa.Repositories.ADO.SQLServer
{
    public class PessoaDAO
    {
        //Declarado para toda a classe. Possível alterar somente no construtor.
        private readonly string connectionString;

        //Quem invocar o construtor do repositório deve enviar a string de conexão.
        public PessoaDAO(string connectionString)
        {
            // atualização do atributo por meio do valor que veio
            // no parâmetro do construtor.
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

        /* Método para Listar todos os Carros. */
        public List<Pessoas> getAll() // get() ou getCarros ou getAllCarros()
        {
            List<Pessoas> pessoas = new List<Pessoas>();
            

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM tb_Pessoa " +
                                          "LEFT JOIN tb_Usuario " +
                                          "ON tb_Usuario.Pessoa_Id = tb_Pessoa.Pessoa_Id;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Pessoas pessoa = new Pessoas();

                        pessoa.Pessoa_Id = (int)dr["Pessoa_Id"];
                        pessoa.Nome = (string)dr["Nome"];
                        pessoa.Sobrenome = (string)dr["Sobrenome"];
                        pessoa.CPF = (string)dr["CPF"];
                        pessoa.CNPJ = (string)dr["CNPJ"];


                        Tb_Usuario usuario = new Tb_Usuario();
                        usuario.Email = (string)dr["Email"].ToString();
                        usuario.Senha = (string)dr["Senha"].ToString();
                        pessoa.Usuarios = usuario;

                        

                        pessoas.Add(pessoa);

                    }

                }

            }
            return pessoas;
        }

        /* Método para listar somente 1 Pessoa-Responsavel */
        public Pessoas getByIdPessoa(int id)
        {
            Pessoas pessoa = new Pessoas();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open(); //Abrir conexão do banco de dados: GrupoEscoteiro

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT P.Pessoa_Id, P.Nome, P.Sobrenome, P.CPF, P.CNPJ, U.Email " +
                                          "FROM tb_Pessoa AS P " +
                                          "LEFT JOIN tb_Usuario AS U " +
                                          "ON U.Pessoa_Id = P.Pessoa_Id " +
                                          "WHERE P.Pessoa_Id = @Pessoa_Id;";

                    command.Parameters.Add(new SqlParameter("@Pessoa_Id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {

                        pessoa.Pessoa_Id = (int)dr["Pessoa_Id"];
                        pessoa.Nome = (string)dr["Nome"];
                        pessoa.Sobrenome = (string)dr["Sobrenome"];                        
                        pessoa.CPF = (string)dr["CPF"];
                        pessoa.CNPJ = (string)dr["CNPJ"];
                        

                        Tb_Usuario usuario = new Tb_Usuario();
                        usuario.Email = (string)dr["Email"];
                        pessoa.Usuarios = usuario;


                    }

                }
            }

            return pessoa;
        }

        public void update(int id, Pessoas pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //Cria o comando (instruão SQL) que será feita a atualização do carro
                    //na tabela do carro no banco de dados CarrosDB
                    command.CommandText = "update tb_Pessoa set Nome = @Nome, " +
                                          "Sobrenome = @Sobrenome, CPF = @CPF, CNPJ = @CNPJ where Pessoa_Id = @Pessoa_Id; ";
                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Sobrenome", System.Data.SqlDbType.VarChar)).Value = pessoa.Sobrenome;
                    command.Parameters.Add(new SqlParameter("@CPF", System.Data.SqlDbType.VarChar)).Value = pessoa.CPF;
                    command.Parameters.Add(new SqlParameter("@CNPJ", System.Data.SqlDbType.VarChar)).Value = pessoa.CNPJ;
                    //command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    //command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;

                    command.Parameters.Add(new SqlParameter("@Pessoa_Id", System.Data.SqlDbType.Int)).Value = pessoa.Pessoa_Id;

                    //Executar a atualização dos dados da tabela carro
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdatePerfil(int id, Pessoas pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //Cria o comando (instruão SQL) que será feita a atualização do carro
                    //na tabela do carro no banco de dados CarrosDB
                    command.CommandText = "update tb_Pessoa set Nome = @Nome, " +
                                          "Sobrenome = @Sobrenome, CPF = @CPF, CNPJ = @CNPJ where Pessoa_Id = @Pessoa_Id; ";
                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Sobrenome", System.Data.SqlDbType.VarChar)).Value = pessoa.Sobrenome;
                    command.Parameters.Add(new SqlParameter("@CPF", System.Data.SqlDbType.VarChar)).Value = pessoa.CPF;
                    command.Parameters.Add(new SqlParameter("@CNPJ", System.Data.SqlDbType.VarChar)).Value = pessoa.CNPJ;
                    //command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    //command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;

                    command.Parameters.Add(new SqlParameter("@Pessoa_Id", System.Data.SqlDbType.Int)).Value = pessoa.Pessoa_Id;

                    //Executar a atualização dos dados da tabela carro
                    command.ExecuteNonQuery();
                }
            }
        }





        public void Adicionar(Pessoas pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();
                Tb_Usuario usuario = new Tb_Usuario();


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    //Cria o comando (instruão SQL) que será feita a inserção do carro
                    //na tabela do carro no banco de dados CarrosDB
                    /*nome, cpf, genero, email, ramos, ativo, voluntario, responsavel, dtnasc, rua, numero, cidade, bairro, 
                     * estado, cep, telefone, telefone_emergencia from Pessoa*/

                    usuario.Nivel = (int)ENiveis.Normal;


                    command.CommandText = "DECLARE @idPessoa TABLE(id int); " +
                        "INSERT INTO tb_Pessoa(Nome, Sobrenome, CPF, CNPJ) " +
                        "OUTPUT inserted.Pessoa_Id INTO @idPessoa " +
                        "values (@Nome, @Sobrenome, @CPF, @CNPJ); " +
                        "DECLARE @newidPessoa INT; " +
                        "SELECT @newidPessoa = id FROM @idPessoa " +
                        "INSERT INTO tb_Usuario(Pessoa_Id, Email, Senha, Nivel) " +
                        "values(@newidPessoa, @Email, @Senha, @Nivel);";

                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@Sobrenome", System.Data.SqlDbType.VarChar)).Value = pessoa.Sobrenome;
                    command.Parameters.Add(new SqlParameter("@CPF", System.Data.SqlDbType.VarChar)).Value = pessoa.CPF;
                    command.Parameters.Add(new SqlParameter("@CNPJ", System.Data.SqlDbType.VarChar)).Value = pessoa.CNPJ;
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = pessoa.Usuarios.Email;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = PessoaDAO.CriptografarSenha(pessoa.Usuarios.Senha);
                    command.Parameters.Add(new SqlParameter("@Nivel", System.Data.SqlDbType.Int)).Value = usuario.Nivel;



                    command.ExecuteNonQuery();

                    // O homem do saco leva ps dados até p SGBD e volta com o valor do id-> ExecuteScalar retorna um único valor.
                    //Observer que o Command.Text foi alterado com mais de uma instrução. Então, as duas instruções são executadas
                    //e temos como retorno o valor do id que foi gerado pelo SGBD na tabela carro. Assim, conseguimos atualizar
                    //o valor do id do objeto carro que antes da inserção era 0
                    //pessoa.Pessoa_Id = (int) command.ExecuteScalar();

                }//finaliza SQLCommand
            }//Finaliza SQLConnection
        }//Fim do método add

        /* Método para Remover um Carro pelo seu identificador (id) */
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    //Cria o comando (instruão SQL) que será feita a remoção do carro
                    //na tabela do carro no banco de dados CarrosDB
                    command.CommandText =   "DELETE FROM tb_Usuario WHERE Usuario_Id = @Usuario_Id;" +
                                            "DELETE FROM tb_Pessoa WHERE Pessoa_Id = @Pessoa_Id; ";
                        

                    command.Parameters.Add(new SqlParameter("@Pessoa_Id", System.Data.SqlDbType.Int)).Value = id;
                    command.Parameters.Add(new SqlParameter("@Usuario_Id", System.Data.SqlDbType.Int)).Value = id;


                    //Executar a remoção dos dados da tabela carro
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

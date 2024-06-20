
using System.ComponentModel.DataAnnotations;

namespace Pexinxa.Models
{
    public class Pessoas
    {
        [Key]
        public int Pessoa_Id { get; set; }
        
        [Required(ErrorMessage ="Campo nome é obrigatório!", AllowEmptyStrings =false)]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Mínimo de 5 e máximo de 100 caracteres")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo cpf é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Mínimo de 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo cnpj é obrigatório!", AllowEmptyStrings = false)]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public Tb_Usuario Usuarios { get; set; }


        public Pessoas()
        {
            this.Pessoa_Id = 0;
            this.Nome = string.Empty;
            this.Sobrenome = string.Empty;
            this.CPF = string.Empty;
            this.CNPJ = string.Empty;
            this.Email = string.Empty;
            this.Senha = string.Empty;
        }
        public Pessoas(int id_pessoa, string nome, string sobrenome, string cpf, string cnpj, string email, string senha)
        {
            this.Pessoa_Id = id_pessoa;
            this.Nome=nome;
            this.Sobrenome=sobrenome;
            this.CPF=cpf;
            this.CNPJ = cnpj;
            this.Email = email;
            this.Senha = senha;
        }


    }

}

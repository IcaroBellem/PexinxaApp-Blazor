using System.ComponentModel.DataAnnotations;

namespace Pexinxa.Models
{
    public class Tb_Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }
        public int Pessoa_Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }

        public Pessoas Pessoas { get; set; }

        public Tb_Usuario()
        {
            this.Usuario_Id = 0;
            this.Pessoa_Id = 0;
            this.Email = string.Empty;
            this.Senha = string.Empty;
            this.Nivel = 0;
        }

        public Tb_Usuario(int usuario_Id, int pessoa_Id, string email, string senha, int nivel)
        {
            Usuario_Id = usuario_Id;
            Pessoa_Id = pessoa_Id;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }
    }
}

namespace Pexinxa.Models
{
    public class Permissao
    {
        public int Id_Permissao { get; set; }
        public string Nome_Permissao { get; set; }
        public string Descricao { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }

        public Permissao()
        {
            this.Id_Permissao = 0;
            this.Nome_Permissao = string.Empty;
            this.Descricao = string.Empty;
            this.CreatedAt = new DateOnly();
            this.UpdatedAt = new DateOnly();
        }
        public Permissao(int id_Permissao, string nome_Permissao, string descricao, DateOnly createdAt, DateOnly updatedAt)
        {
            Id_Permissao = id_Permissao;
            Nome_Permissao = nome_Permissao;
            Descricao = descricao;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}

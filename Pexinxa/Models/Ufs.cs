namespace Pexinxa.Models
{
    public class Ufs
    {
        public int UF_Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public Ufs() 
        { 
            this.UF_Id = 0;
            this.Sigla = string.Empty;
            this.Nome = string.Empty;
        }
        public Ufs(int uf_id, string sigla, string nome)
        {
            UF_Id = uf_id;
            Sigla = sigla;
            Nome = nome;
        }
    }
}

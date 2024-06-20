namespace Pexinxa.Models
{
    public class Lista
    {
        public int Id_Lista { get; set; }
        public string Nome_Lista { get; set; }
        public int Id_Pessoa { get; set; }

        public Lista () 
        { 
            this.Id_Lista = 0;
            this.Nome_Lista = string.Empty;
            this.Id_Pessoa = 0;
        }
        public Lista(int id_Lista, string nome_Lista, int id_Pessoa)
        {
            Id_Lista = id_Lista;
            Nome_Lista = nome_Lista;
            Id_Pessoa = id_Pessoa;
        }
    }

}

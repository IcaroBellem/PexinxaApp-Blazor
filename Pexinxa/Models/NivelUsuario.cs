namespace Pexinxa.Models
{
    public class NivelUsuario
    {
        public int Id_NivelUsuario { get; set; }
        public string Descricao { get; set; }

        public NivelUsuario()
        {
            this.Id_NivelUsuario = 0;
            this.Descricao = String.Empty;
        }
        public NivelUsuario(int id_NivelUsuario, string descricao)
        {
            Id_NivelUsuario = id_NivelUsuario;
            Descricao = descricao;
        }
    }
}

namespace Pexinxa.Models
{
    public class ListaProduto : Lista
    {
        public int Lista_Produto_Id { get; set; }
        public int Produto_Id { get; set; }
        public int Quantidade { get; set; }

        public ListaProduto() 
        { 
            this.Lista_Produto_Id = 0;
            this.Produto_Id = 0;
            this.Quantidade = 0;
        }
        public ListaProduto(int lista_produto_id, int produto_Id, int quantidade)
        {
            Lista_Produto_Id = lista_produto_id;
            Produto_Id = produto_Id;
            Quantidade = quantidade;
        }
    }
}

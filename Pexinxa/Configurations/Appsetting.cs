namespace Pexinxa.Configurations
{
    public class Appsetting
    {
        // Esse método foi criado para dizer qual chave deve ser consultada 
        // No arquivo appsettins.json que está localizado logo abaixo da pasta
        // Views. Ele foi criado para facilitar a alteração da
        //string de conexão sem precisar recompilar o código da aplicação Web.

        public static string getKeyConnectionString()
        {
            return "PexinxaConnection";
        }
    }
}

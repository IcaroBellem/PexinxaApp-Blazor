using Pexinxa.Models;

namespace Pexinxa.Services
{
    public interface ISessao
    {
        void addTokenLogin(Tb_Usuario usuario);

        Tb_Usuario getTokenLogin();

        // Adicionar na Classe Sessão (Sessao.cs) todos os métodos que estarão protegidos pela sessão.
        // Por exemplo: void update() do CarroController.
        void deleteTokenLogin();
    }
}

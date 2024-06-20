using Newtonsoft.Json;
using Pexinxa.Models;

namespace Pexinxa.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "login";
        }

        public void addTokenLogin(Tb_Usuario usuario)
        {
            string loginTokenJson = JsonConvert.SerializeObject(usuario);
            this.httpContextAccessor.HttpContext.Session.SetString(this.tokenSessao, loginTokenJson);
        }
        public Tb_Usuario getTokenLogin()
        {
            string loginTokenJson = this.httpContextAccessor.HttpContext.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Tb_Usuario>(loginTokenJson) : null;
        }

        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext.Session.Remove(this.tokenSessao);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Pexinxa.Models;
using Pexinxa.Repositories.ADO.SQLServer;
using Pexinxa.Services;
using System.Security.Cryptography;
using System.Text;

namespace Pexinxa.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.EmailDAO repository;
        private readonly Repositories.ADO.SQLServer.PessoaDAO repositoryPessoa;


        public LoginController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.EmailDAO(configuration.GetConnectionString(Configurations.Appsetting.getKeyConnectionString()));
            this.repositoryPessoa = new Repositories.ADO.SQLServer.PessoaDAO(configuration.GetConnectionString(Configurations.Appsetting.getKeyConnectionString()));
        }

        //Criptografia de Senha
        public static string CriptografarSenha(string Senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Tb_Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            {
                ViewBag.ErrorMessage = "E-mail e/ou Senha Inválido!";
                return RedirectToAction("Login", "Login");
            }

            if (this.repository.check(usuario))
            {
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Senha", LoginController.CriptografarSenha(usuario.Senha));
                HttpContext.Session.SetString("Id", usuario.Pessoa_Id.ToString());

                if (usuario.Nivel == (int)ENiveis.Admin)
                {
                    HttpContext.Session.SetString("admin", usuario.Nivel.ToString());
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }







        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Login(Email email)
        //{
        //    #region "Login com controle de sessão."
        //    if (!string.IsNullOrEmpty(email.Endereco) && !string.IsNullOrEmpty(email.Senha))
        //    {
        //        if (this.repository.check(email))
        //        {
        //            var loginResultado = repository.getTipo(email);
        //            this.sessao.addTokenLogin(email);

        //            if (loginResultado.TipoUsuario == "admin")
        //                return RedirectToAction("Index", "Admin"); // Redireciona para o local do usuário Admin.
        //            return RedirectToAction("Index", "Home"); // Redireciona para outro local(usuário comum).
        //        }
        //        ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
        //    }
        //    return View();
        //    #endregion
        //}
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}

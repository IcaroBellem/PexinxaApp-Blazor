using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pexinxa.Models;

namespace Pexinxa.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Repositories.ADO.SQLServer.PessoaDAO repository;

        // objeto configuration => parte do framework que permite ler o
        //                         arquivo appsettings.json - GetConnectionString => método
        //                         do framework que permite ler a chave ConnectionStrings deste arquivo.
        public PessoaController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.PessoaDAO(configuration.GetConnectionString(Configurations.Appsetting.getKeyConnectionString()));
            // Configurations.Appsettings.getKeyConnectionString() => nossa classe de configuração
            //    para trazer a chave que deve ser lida, neste caso: DefaultConnection.
        }
        // GET: PessoaController
        public IActionResult Index()
        {
            return View(this.repository.getAll());
        }

        // GET: PessoaController/Details/5
        public IActionResult Detalhes(int id)
        {
            return View(this.repository.getByIdPessoa(id));
        }

        // GET => getByIdCarro(id): CarrosController/Edit/5 (id)
        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(this.repository.getByIdPessoa(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Pessoas pessoa)
        {
            try
            {
                this.repository.update(id, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public IActionResult EditarPerfil(int id)
        {
            var usuario =  this.repository.getByIdPessoa(id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPerfil(int id, Pessoas pessoa)
        {
            var usuarioA = this.repository.getByIdPessoa(id);
            usuarioA.Pessoa_Id = pessoa.Pessoa_Id;
            try
            {
                this.repository.UpdatePerfil(id, usuarioA);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoas pessoa)
        {
            try
            {
                this.repository.Adicionar(pessoa);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }





        [HttpGet]
        public IActionResult Deletar(int id)
        {
            this.repository.Deletar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

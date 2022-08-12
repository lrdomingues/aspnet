using ContactManagement.Models;
using ContactManagement.Repositório;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio =  contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MenssagemSucesso"] = "Contato excluído com sucesso";
                }
                else
                {
                    TempData["MenssagemErro"] = "Não foi possível excluir";
                }
                
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["MenssagemErro"] = $"Não foi possível excluir: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contact);
                    TempData["MenssagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch(Exception e)
            {
                TempData["MenssagemErro"] = $"Não foi possível cadastrar: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contact);
                    TempData["MenssagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contact);
            }
            catch(Exception e)
            {
                TempData["MenssagemErro"] = $"Não foi possível alterar: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

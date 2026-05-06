using Microsoft.AspNetCore.Mvc;
using SistemaMVC.Context;
using SistemaMVC.Models;
using System.Linq;
using SistemaMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SistemaMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ================= CRIAR =================

        public IActionResult CriarContato(int? pessoaId)
        {
            var viewModel = new AgendaTarefasViewModel
            {
                Pessoas = _context.Pessoas.ToList(),
                Contato = new Contato { PessoaId = pessoaId ?? 0 }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CriarContato(AgendaTarefasViewModel ViewModel)
        {
            

            if (ModelState.IsValid)
            {
                _context.Contatos.Add(ViewModel.Contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(ViewModel);
        }

        public IActionResult BuscarContato(int id)
        {
            var contato = _context.Contatos.Include(c => c.Pessoa).FirstOrDefault(c => c.Id == id);

            if (contato != null)
            {
                return View(contato);
            }
            return NotFound();
        }
        // ================= LISTAR =================

        public IActionResult ListarContatos()
        {
            var contatos = _context.Contatos
                .Include(c => c.Pessoa)
                    .ThenInclude(p => p.Enderecos)
                .ToList();
            return View(contatos);
        }

        // ================= ATUALIZAR =================

        [HttpGet]
        public IActionResult AtualizarContato(int id)
        {
            var contatoDB = _context.Contatos.Find(id);

            if (contatoDB == null)
                return NotFound();

            var viewModel = new AgendaTarefasViewModel
            {
                Contato = contatoDB,
                Pessoas = _context.Pessoas.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AtualizarContato(int id, AgendaTarefasViewModel viewModel)
        {
            var contato = viewModel.Contato;
            var contatoDB = _context.Contatos.Find(id);

            if (contatoDB == null)
                return NotFound();

            contatoDB.PessoaId = contato.PessoaId;
            contatoDB.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ================= EXCLUIR =================

        public IActionResult ExcluirContato(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaMVC.Context;
using SistemaMVC.Models;
using SistemaMVC.ViewModels;
using System.Linq;

namespace SistemaMVC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AgendaContext _context;

        public EnderecoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var enderecos = _context.Enderecos.Include(e => e.Pessoa).ToList();
            return View(enderecos);
        }

        public IActionResult Criar(int? pessoaId)
        {
            var viewModel = new EnderecosViewModel
            {
                Pessoas = _context.Pessoas.ToList(),
                Endereco = new Endereco { PessoaId = pessoaId ?? 0 }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Criar(EnderecosViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(viewModel.Endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Pessoas = _context.Pessoas.ToList();
            return View(viewModel);
        }

        public IActionResult Editar(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return NotFound();

            var viewModel = new EnderecosViewModel
            {
                Endereco = endereco,
                Pessoas = _context.Pessoas.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(EnderecosViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Enderecos.Update(viewModel.Endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Pessoas = _context.Pessoas.ToList();
            return View(viewModel);
        }

        public IActionResult Excluir(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return NotFound();
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

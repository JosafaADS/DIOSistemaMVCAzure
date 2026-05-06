using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC.Models;
using SistemaMVC.Context;
using Microsoft.EntityFrameworkCore;

namespace SistemaMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly AgendaContext _context;

        public PessoaController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pessoas = _context.Pessoas.ToList();
            return View(pessoas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null) return NotFound();
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Pessoas.Update(pessoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public IActionResult Detalhes(int id)
        {
            var pessoa = _context.Pessoas
                .Include(p => p.Enderecos)
                .Include(p => p.Contatos)
                .FirstOrDefault(p => p.Id == id);
            if (pessoa == null) return NotFound();
            return View(pessoa);
        }

        public IActionResult Excluir(int id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null) return NotFound();
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
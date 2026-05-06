using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMVC.Models;

namespace SistemaMVC.ViewModels
{
    public class AgendaTarefasViewModel
    {
        public Contato Contato{ get; set; }
        public List<Pessoa> Pessoas{ get; set; }
        
    }
}
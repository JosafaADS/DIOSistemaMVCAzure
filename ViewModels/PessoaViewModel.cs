using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMVC.Models;

namespace SistemaMVC.ViewModels
{
    public class PessoaViewModel
    {
        public Pessoa Pessoa{ get; set; }
        public List<Endereco> Enderecos{ get; set; }
        
    }
}
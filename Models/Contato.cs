using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaMVC.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uma pessoa deve ser selecionada")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Display(Name = "Status")]
        public bool Ativo { get; set; }
    }
}

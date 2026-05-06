using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaMVC.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Uma pessoa deve ser selecionada")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório")]
        public string Rua { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        public string Cidade { get; set; }

        public string Bairro { get; set; }
    }
}
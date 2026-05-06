using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaMVC.Models;
using SistemaMVC.Context;

namespace SistemaMVC.Context
{
    public class AgendaContext : DbContext
    {
        //contrutor da conexao com BD AgendaMVC
        public AgendaContext (DbContextOptions<AgendaContext> options) : base (options)
        {
            
        }
        //Define as tabelas do banco dados, uma lista de objetos dos Modelos de campos (cada item da lista representa um registro
        //da tabela, que é um objeto do mesmo tipo da lista. Ou seja uma lista DbSet de um tipo de modelo, contem objeto preenchido em cada item da lista
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set;}
    }
}
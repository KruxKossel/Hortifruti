using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Funcionario(string nome, string cpf, string cargo) : Pessoa(nome, cpf)
    {
        public int Id { get;}
        public string Cargo { get; set; } = cargo;
    }
}
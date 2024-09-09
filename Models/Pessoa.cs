using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Pessoa(string nome, string cpf)
    {
        public string Nome { get; set; } = nome;
        public string Cpf { get; set; } = cpf;
        
    }
}
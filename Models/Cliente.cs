using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Cliente(string nome, string cpf, string telefone) : Pessoa (nome, cpf)
    {
        public int Id { get;}
        public string Telefone { get;} = telefone;
    }
}
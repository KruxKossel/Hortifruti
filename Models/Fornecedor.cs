using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortifruti.Models
{
    public class Fornecedor(string razaoSocial, string cnpj, string telefone)
    {

        public int Id { get; }
        public string RazaoSocial { get; } = razaoSocial;
        public string Cnpj { get; } = cnpj;
        public string Telefone { get; } = telefone;
        
    }
}